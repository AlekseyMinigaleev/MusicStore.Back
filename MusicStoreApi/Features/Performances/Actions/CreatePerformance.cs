using Azure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MusicStore.DB.DataAccess;
using MusicStore.DB.Enums;
using MusicStore.DB.Models;
using System.Globalization;

namespace MusicStoreApi.Features.Performances.Actions
{
    public class CreatePerformance
    {
        public class Command :IRequest<ResponseViewModel>
        {
            public string Place { get;  set; }

            public string Name { get;  set; }

            public Guid EnsembleId { get; set; }

            public string Duration { get; set; }

            public MusicTempo Tempo { get; set; }

            public string Interpretation { get;  set; }
        }

        public class ResponseViewModel
        {
            public string Name { get; set; }

            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, ResponseViewModel>
        {
            private readonly MusicStoreDbContext _dbContext;

            public Handler(MusicStoreDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ResponseViewModel> Handle(Command request, CancellationToken cancellationToken)
            {
                TimeSpan.TryParseExact(
                    request.Duration,
                    "h\\:m",
                    CultureInfo.InvariantCulture,
                    out var duration);

                var ensemble = await _dbContext.Ensembles
                    .FirstAsync(x => x.Id == request.EnsembleId, cancellationToken);

                var musicalMetadata = new MusicalMetadata(
                    duration,
                    request.Tempo,
                    request.Interpretation);

                var performance = new Performance(
                    place: request.Place,
                    name: request.Name,
                    ensambel: ensemble,
                    musicalMetadata: musicalMetadata,
                    music: null);

                await _dbContext.Performances.AddAsync(performance, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                var response = new ResponseViewModel
                {
                    Id = performance.Id,
                    Name = performance.Name
                };

                return response;
            }
        }
    }
}
