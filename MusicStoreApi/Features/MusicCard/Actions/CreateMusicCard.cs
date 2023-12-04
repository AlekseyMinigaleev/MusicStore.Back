using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStore.DB.DataAccess;
using MusicStore.DB.Models;

namespace MusicStore.Api.Features.MusicCard.Actions
{
    public class CreateMusicCard
    {
        public class Command : IRequest
        {
            public string Name { get; set; }

            public string Genre { get; set; }

            public Guid AuthorId { get; set; }

            public Performances[] Performances { get; set; }
        }

        public class Performances 
        {
            public Guid Id { get; set; }

            public string Name { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator(MusicStoreDbContext dbContext)
            {
                RuleFor(x => x.AuthorId)
                    .MustAsync(async (songWriterId, cancellationToken) =>
                    {
                        var songWritter = await dbContext.Songwriters
                        .FirstOrDefaultAsync(
                            songWriter => songWriter.Id == songWriterId,
                            cancellationToken);

                        return songWritter is not null;
                    })
                    .WithMessage("the author with specified id does not exist");

                RuleFor(x => x.Performances.Select(x=>x.Id))
                    .MustAsync(async (command, performanceIds, validationContext, cancellationToken) =>
                    {
                        var nonExistentIds = new List<Guid>();

                        foreach (var performanceId in performanceIds)
                        {
                            var performance = await dbContext.Performances
                                .FirstOrDefaultAsync(x => x.Id == performanceId, cancellationToken);
                            if (performance is null)
                                nonExistentIds.Add(performanceId);
                        }

                        if (nonExistentIds.Any())
                        {
                            nonExistentIds.ForEach(id =>
                                validationContext
                                    .AddFailure($"Performance with ID {id} does not exist.")
                                );

                            return false;
                        }

                        return true;
                    })
                    .WithMessage("One or more performances do not exist in the database.");
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly MusicStoreDbContext _dbContext;

            public Handler(
                MusicStoreDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var author = await _dbContext.Songwriters
                    .FirstAsync(
                        x => x.Id == request.AuthorId,
                        cancellationToken);

                var pefrormances = _dbContext.Performances
                    .Where(x => request.Performances.Select(x=>x.Id).Contains(x.Id))
                    .ToHashSet();

                var music = new Music(
                    author: author,
                    name: request.Name,
                    genre: request.Genre,
                    performances: pefrormances,
                    compactDisks: new HashSet<CompactDisk>());

                await _dbContext.AddAsync(music, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}