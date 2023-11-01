using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStore.DB.DataAccess;
using MusicStore.DB.Models;

namespace MusicStore.Api.Features.Performances.Actions
{
    public class GetPerformancesByMusicId
    {
        public class Query : IRequest<ViewModel[]>
        {
            public Guid musicCardId { get; set; }
        }

        public class ViewModel
        {
            public Guid Id { get; private set; }

            public string Place { get; private set; }

            public string Name { get; private set; }

            public Ensemble Ensemble { get; private set; }

            public Music Music { get; private set; }

            public MusicalMetadata MusicalMetadata { get; private set; }
        }

        public class ViewModelProfiler : Profile
        {
            public ViewModelProfiler()
            {
                CreateMap<Performance, ViewModel>();
            }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator(MusicStoreDbContext dbContext)
            {
                RuleFor(x => x.musicCardId)
                    .MustAsync(async (id, cancellationToken) =>
                    {
                        var result = await dbContext.Musics.FirstOrDefaultAsync(x => x.Id == id);

                        return result is not null;
                    })
                    .WithMessage("the musicCard with specified id does not exist");
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

            public async Task<ViewModel[]> Handle(Query request, CancellationToken cancellationToken)
            {
                var reuslt = await _dbContext.Performances
                    .Where(x => x.MusicId == request.musicCardId)
                    .ProjectTo<ViewModel>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken);

                return reuslt;
            }
        }
    }
}