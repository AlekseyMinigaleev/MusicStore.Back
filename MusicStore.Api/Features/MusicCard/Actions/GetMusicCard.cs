using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStore.DB.DataAccess;
using MusicStore.DB.Enums;
using MusicStore.DB.Models;
using MusicStore.DB.TDOs;

namespace MusicStore.Api.Features.MusicCard.Actions
{
    public class GetMusicCard
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
                    .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.LastName} {src.Author.FirstName}"))
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

                var music = _dbContext.Musics.First();
                var typeRulesDto =new []{ new EnsembleTypeRuleDto()
                {
                    Type ="123",
                    HasComposer = true,
                    HasLeader = true,
                    HasOrchestraConductor = true,
                    MusicalInstrumentCount = new Dictionary<string, int> {[""] = 1 }
                } };

                var ensemble = new Ensemble(
                    musicants: Array.Empty<Musicant>().ToHashSet(),
                    ensumbleTypeRuleDto: typeRulesDto,
                    performance: Array.Empty<Performance>().ToHashSet()
                    );

                var musicalMetadata = new MusicalMetadata(
                    12.6,
                    MusicTempo.Adagietto,
                    "123"
                    );

                var performance = new Performance(
                    place: "",
                    name: "",
                    ensambel: ensemble,
                    musicalMetadata: musicalMetadata,
                    music: music
                    );

                _dbContext.Performances.Add(performance);
                _dbContext.SaveChanges();

                var musicCards = await _dbContext.Musics
                    .ProjectTo<MusicCardViewModel>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken);

                return musicCards;
            }
        }
    }
}