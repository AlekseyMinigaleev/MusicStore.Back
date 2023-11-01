using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Api.Features.Ensembles.Actions;

namespace MusicStore.Api.Features.Ensembles
{
    public class EnsembleController : BaseApiController
    {
        public EnsembleController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetEnsemlesAsync(CancellationToken cancellationToken)
        {
            var query = new GetEnsembles.Query();

            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
