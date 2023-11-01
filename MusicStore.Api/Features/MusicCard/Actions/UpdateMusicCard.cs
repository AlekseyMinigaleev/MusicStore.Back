using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStore.DB.DataAccess;

namespace MusicStore.Api.Features.MusicCard.Actions
{
    public class UpdateMusicCard
    {
        public class Command : IRequest
        {
            public Guid MusicCardId { get; set; }

            public string Name { get; set; }

            public string Genre { get; set; }

            public Guid AuthorId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator(MusicStoreDbContext dbContext)
            {
                RuleFor(x => x.MusicCardId)
                    .MustAsync(async (musicCardId, cancellationToken) =>
                    {
                        var music = await dbContext.Musics
                        .FirstOrDefaultAsync(
                            music => music.Id == musicCardId,
                            cancellationToken);

                        return music is not null;
                    })
                    .WithMessage("the music card with specified id does not exist");

                RuleFor(x => x.AuthorId)
                    .MustAsync(async (authorId, cancellationToken) =>
                    {
                        var songwriter = await dbContext.Songwriters
                        .SingleOrDefaultAsync(
                            x => x.Id == authorId,
                            cancellationToken);

                        return songwriter is not null;
                    })
                    .WithMessage("the author with the specified id does not exist ");
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly MusicStoreDbContext _dbContext;

            public Handler(MusicStoreDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task Handle(
                Command request,
                CancellationToken cancellationToken)
            {
                var music = await _dbContext.Musics
                    .SingleAsync(x => x.Id == request.MusicCardId, cancellationToken);

                music.Update(
                        request.AuthorId,
                        request.Name,
                        request.Genre);

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}