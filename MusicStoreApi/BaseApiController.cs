﻿using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MusicStore.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected IMediator Mediator;

        public BaseApiController(
            IMediator mediator)
        {
            Mediator = mediator;
        }

        protected async Task ValidateAndChangeModelStateAsync<T>(
            IValidator<T> validator,
            T instance,
            CancellationToken cancellationToken = default)
        {
            var validationResult = await validator
                .ValidateAsync(instance, cancellationToken);

            if (!validationResult.IsValid)
                ChangeModelState(validationResult.Errors);
        }

        private void ChangeModelState(IEnumerable<ValidationFailure> errors)
        {
            foreach (var item in errors)
                ModelState.AddModelError(
                    item.ErrorCode,
                    item.ErrorMessage);
        }
    }
}
