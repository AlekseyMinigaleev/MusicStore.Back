using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Api.Features.SongWriter.Action;

namespace MusicStore.Api.Features.SongWriter
{
    public class SongWriterController : BaseApiController
    {
        public SongWriterController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult> GetSongwriters(CancellationToken cancellationToken)
        {
            var query = new GetSongwriters.Query();

            var result = await Mediator.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}
