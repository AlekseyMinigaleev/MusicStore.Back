using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStore.Api.Features.MusicCard.ViewModels;
using MusicStore.DB.DataAccess;

namespace MusicStore.Api.Features.MusicCard.Actions
{
    public class GetListMusicCards
    {
        public class Query : IRequest<MusicCardViewModel[]>
        { }

        public class Handler : IRequestHandler<Query, MusicCardViewModel[]>
        {
            public readonly MusicStoreDbContext _dbContext;
            public readonly IMapper _mapper;

            public Handler(
                MusicStoreDbContext dbContext,
                IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<MusicCardViewModel[]> Handle(
                Query request,
                CancellationToken cancellationToken)
            {
                var musicCards = await _dbContext.Musics
                    .ProjectTo<MusicCardViewModel>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken);

                return musicCards;
            }
        }
    }
}