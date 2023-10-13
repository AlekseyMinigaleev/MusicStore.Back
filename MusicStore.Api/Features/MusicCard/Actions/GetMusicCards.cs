using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStore.DB.DataAccess;
using MusicStore.DB.Models;

namespace MusicStore.Api.Features.MusicCard.Actions
{
    public class GetMusicCards
    {
        public class Query : IRequest<MusicCardViewModel[]>
        { }

        public class MusicCardViewModel
        {
            public Guid Id { get; set; }

            public string MusicName { get; set; }

            public string Genre { get; set; }

            public string Author { get; set; }

            public int PerformanceCount { get; set; }
        }

        public class MusicCardViewModelProfiler : Profile
        {
            public MusicCardViewModelProfiler()
            {
                CreateMap<Music, MusicCardViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.MusicName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                    .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Autor))
                    .ForMember(dest => dest.PerformanceCount, opt => opt.MapFrom(src => src.Performances.Count()));
            }
        }

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