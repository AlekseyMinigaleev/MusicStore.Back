using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Api.Features.CompactDisks.Action;

namespace MusicStore.Api.Features.CompactDisks
{
    public class CompactDiskController : BaseApiController
    {
        public CompactDiskController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult> GetDetailedCompactDisk(
            [FromQuery] GetDetaildeCompactDisk.Query request,
            [FromServices] IValidator<GetDetaildeCompactDisk.Query> validator,
            CancellationToken cancellationToken)
        {
            await ValidateAndChangeModelStateAsync(validator, request, cancellationToken);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await Mediator.Send(request, cancellationToken));

        }
    }
}
