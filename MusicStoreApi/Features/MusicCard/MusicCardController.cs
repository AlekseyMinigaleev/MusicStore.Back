using Bogus;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Api.Features.MusicCard.Actions;
using MusicStore.DB.DataAccess;

namespace MusicStore.Api.Features.MusicCard
{
    public class MusicCardController : BaseApiController
    {
        public MusicCardController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetListMusicCardAsync(CancellationToken cancellationToken)
        {
            var query = new GetListMusicCards.Query();
            var result = await Mediator.Send(query, cancellationToken);

            return Ok(result);  
        }

        [HttpGet("Get/{MusicCardId}")]
        public async Task<ActionResult>GetMusicCardAsync(
           [FromRoute]GetMusicCard.Query query,
           [FromServices] IValidator<GetMusicCard.Query> validator,
           CancellationToken cancellationToken)
        {
            await ValidateAndChangeModelStateAsync(validator, query, cancellationToken);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await Mediator.Send(query, cancellationToken));
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
