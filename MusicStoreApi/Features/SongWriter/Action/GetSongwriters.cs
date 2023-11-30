using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStore.DB.DataAccess;
using MusicStore.DB.Models;

namespace MusicStore.Api.Features.SongWriter.Action
{
    public class GetSongwriters
    {
        public class Query : IRequest<ViewModel[]>
        { }

        public class ViewModel
        {
            public Guid Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string? Patronomyc { get; set; }
        }

        public class ViewModelProfiler : Profile
        {
            public ViewModelProfiler()
            {
                CreateMap<Songwriter, ViewModel>();
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
                var result = await _dbContext.Songwriters
                    .OrderBy(x => x.Musics.Count())
                    .ProjectTo<ViewModel>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken);

                return result;
            }
        }
    }
}