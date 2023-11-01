using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MusicStore.DB.DataAccess;
using MusicStore.DB.Models;

namespace MusicStore.Api.Features.Ensembles.Actions
{
    public class GetEnsembles
    {
        public class Query : IRequest<ViewModel[]>
        {

        }

        public class ViewModel
        {
            public Guid Id { get; set; }

            public string Type { get; set; }

            public string Name { get; set; }

            public int PerfomancesCount { get; set; }

            public Musicant[] Musicants { get; set; }
        }

        public class ViewModelProfiler : Profile
        {
            public ViewModelProfiler()
            {
                CreateMap<Ensemble, ViewModel>()
                    .ForMember(dest => dest.Musicants, opt => opt.MapFrom(src => src.Musicants))
                    .ForMember(dest => dest.PerfomancesCount, opt => opt.MapFrom(src => src.Performances.Count()))
                    ;
            }
        }

        public class Handler : IRequestHandler<Query, ViewModel[]>
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

            public Task<ViewModel[]> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = _dbContext.Ensembles
                    .ProjectTo<ViewModel>(_mapper.ConfigurationProvider)
                    .OrderBy(x => x.Name)
                        .ThenBy(x=>x.PerfomancesCount)
                    .ToArrayAsync(cancellationToken);

                return result;
            }
        }
    }
}
