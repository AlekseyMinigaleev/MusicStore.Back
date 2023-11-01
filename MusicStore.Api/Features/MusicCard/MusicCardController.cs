using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Api.Features.MusicCard.Actions;

namespace MusicStore.Api.Features.MusicCard
{
    public class MusicCardController : BaseApiController
    {
        public MusicCardController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetMusicCardAsync(CancellationToken cancellationToken)
        {
            var query = new GetMusicCard.Query();
            var result = await Mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateMusicCardAsync(
            [FromBody] UpdateMusicCard.Command command,
            [FromServices] IValidator<UpdateMusicCard.Command> validator,
            CancellationToken cancellationToken)
        {
            await ValidateAndChangeModelStateAsync(validator, command, cancellationToken);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await Mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateMusicCardAsync(
            [FromBody] CreateMusicCard.Command command,
            [FromServices] IValidator<CreateMusicCard.Command> validator,
            CancellationToken cancellationToken)
        {
            await ValidateAndChangeModelStateAsync(validator, command, cancellationToken);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteMusicCardAsync(
            [FromBody] DeleteMusicCard.Command command,
            [FromServices] IValidator<DeleteMusicCard.Command> validator,
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
