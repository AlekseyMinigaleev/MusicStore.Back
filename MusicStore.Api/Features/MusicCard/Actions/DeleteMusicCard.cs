using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStore.DB.DataAccess;

namespace MusicStore.Api.Features.MusicCard.Actions
{
    public class DeleteMusicCard
    {
        public class Query : IRequest
        {
            public Guid[] Ids { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator(MusicStoreDbContext dbContext)
            {
                RuleFor(x => x.Ids)
                    .MustAsync(async (command, Ids, validationContext, cancellationToken) =>
                    {
                        var nonExistentIds = new List<Guid>();

                        foreach (var id in Ids)
                        {
                            var performance = await dbContext.Musics
                                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
                            if (performance is null)
                                nonExistentIds.Add(id);
                        }

                        if (nonExistentIds.Any())
                        {
                            nonExistentIds.ForEach(id =>
                                validationContext
                                    .AddFailure($"music card with ID {id} does not exist.")
                                );

                            return false;
                        }

                        return true;
                    })
                    .WithMessage("One or more music card ids does not exist in the database.");
            }
        }

        public class Handler : IRequestHandler<Query>
        {
            private readonly MusicStoreDbContext _dbContext;

            public Handler(MusicStoreDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task Handle(Query request, CancellationToken cancellationToken)
            {
                var musics = await _dbContext.Musics
                    .Where(x => request.Ids.Contains(x.Id))
                    .ToArrayAsync(cancellationToken);

                _dbContext.Musics.RemoveRange(musics);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}