using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Api.Features.Performances.Actions;

namespace MusicStore.Api.Features.Performances
{
    public class PerformanceController : BaseApiController
    {
        public PerformanceController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("GetList/{musicCardId}")]
        public async Task<ActionResult> GetPerformancesByMusicId(
            [FromRoute] GetPerformancesByMusicId.Query query,
            [FromServices] IValidator<GetPerformancesByMusicId.Query> validator,
            CancellationToken cancellationToken)
        {
            await ValidateAndChangeModelStateAsync(validator, query,cancellationToken);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
