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
        public async Task<ActionResult> GetMusicCards(CancellationToken cancellationToken)
        {
            var query = new GetMusicCards.Query();
            var result = await Mediator.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}
