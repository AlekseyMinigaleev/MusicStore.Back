using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStore.DB.DataAccess;
using MusicStore.DB.Models;
using static MusicStore.Api.Features.MusicCard.Actions.GetMusicCard;

namespace MusicStore.Api.Features.CompactDisks.Action
{
    public class GetDetaildeCompactDisk
    {
        public class Query : IRequest<CDViweModel>
        {
            public Guid Id { get; set; }
        }

        public class CDViweModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public DateTime CreationDate { get; set; }
            public decimal RetailPrice { get; set; }
            public decimal WhosalerPrice { get; set; }
            public MusicViewModel Music { get; set; }
            public string ManufacturingCompanyName { get; set; }
        }

        public class MusicViewModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Genre { get; set; }
            public string Author { get; set; }
            public PerformanceViewModel[] Performances { get; set; }
        }

        public class PerformanceViewModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Place { get; set; }
            public string EnsembleName { get; set; }
        }

        public class CDViewModelProfiler : Profile
        {
            public CDViewModelProfiler()
            {
                CreateMap<CompactDisk, CDViweModel>()
                    .ForMember(dest => dest.Music, opt => opt.MapFrom(src => src.Music))
                    .ForMember(dest => dest.ManufacturingCompanyName, opt => opt.MapFrom(src => src.ManufacturingCompany.Name))
                    .ForMember(dest => dest.ManufacturingCompanyName, opt => opt.MapFrom(src => src.ManufacturingCompany.Name));

                CreateMap<Music, MusicViewModel>()
                    .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.LastName} {src.Author.FirstName} {src.Author.Patronomyc}"))
                    .ForMember(dest => dest.Performances, opt => opt.MapFrom(src => src.Performances));

                CreateMap<Performance, PerformanceViewModel>()
                   .ForMember(dest => dest.EnsembleName, opt => opt.MapFrom(src => src.Ensemble.Name));
            }
        }

        public class QuerValidator : AbstractValidator<Query>
        {
            public QuerValidator(MusicStoreDbContext dbContext)
            {
                RuleFor(x => x.Id)
                    .MustAsync(async (compactDiskId, cancellationToken) =>
                    {
                        var compactDisk = await dbContext.CompactDisks
                        .FirstOrDefaultAsync(
                            compactDisk => compactDisk.Id == compactDiskId,
                            cancellationToken);

                        return compactDisk is not null;
                    })
                    .WithMessage("the compactDisk with specified id does not exist");
            }
        }


        public class Handler : IRequestHandler<Query, CDViweModel>
        {
            private readonly MusicStoreDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(
                MusicStoreDbContext dbContext,
                IMapper mapper)
            {
                _dbContext= dbContext;
                _mapper = mapper;
            }

            public async Task<CDViweModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var a = await _dbContext.CompactDisks
                     .Where(x => x.Id == request.Id)
                     .ProjectTo<CDViweModel>(_mapper.ConfigurationProvider)
                     .FirstAsync(cancellationToken);

                return a;
            }
        }
    }
}