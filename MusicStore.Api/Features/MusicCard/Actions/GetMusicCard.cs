using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStore.Api.Features.MusicCard.ViewModels;
using MusicStore.DB.DataAccess;

namespace MusicStore.Api.Features.MusicCard.Actions
{
    public class GetMusicCard
    {
        public class Query:IRequest<MusicCardViewModel>
        {
            public Guid MusicCardId { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator(MusicStoreDbContext dbContext)
            {
                RuleFor(x => x.MusicCardId)
                    .MustAsync(async (musicCardId, cancellationToken) =>
                    {
                        var music = await dbContext.Musics.SingleOrDefaultAsync(x => x.Id == musicCardId, cancellationToken);

                        return music is not null;
                    });
            }
        }

        public class Handler : IRequestHandler<Query, MusicCardViewModel>
        {
            private readonly MusicStoreDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(
                MusicStoreDbContext dbContext,
                IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<MusicCardViewModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var music = await _dbContext.Musics
                    .Include(x => x.Author)
                    .Include(x => x.Performances)
                    .SingleAsync(x => x.Id == request.MusicCardId, cancellationToken: cancellationToken);

                var musicCard = _mapper.Map<MusicCardViewModel>(music);

                return musicCard;
            }
        }
    }
}