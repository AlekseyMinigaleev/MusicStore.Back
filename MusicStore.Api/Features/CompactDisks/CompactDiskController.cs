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

        [HttpGet("Get/{MusicId}")]
        public async Task<ActionResult> GetCompactDisk(
            [FromRoute] GetCompactDisk.Query request,
            [FromServices] IValidator<GetCompactDisk.Query> validator,
            CancellationToken cancellationToken)
        {
            await ValidateAndChangeModelStateAsync(validator, request, cancellationToken);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await Mediator.Send(request, cancellationToken));
        }


        [HttpGet("List")]
        public async Task<ActionResult> GetListCompactDisk(
            CancellationToken cancellationToken)
        {
            var request = new GetListCompactDisks.Query();

            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateCompactDisk(
            [FromBody] CreateCompactDisk.Query command,
            [FromServices] IValidator<CreateCompactDisk.Query> validator,
            CancellationToken cancellationToken)
        {
            await ValidateAndChangeModelStateAsync(validator, command, cancellationToken);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
