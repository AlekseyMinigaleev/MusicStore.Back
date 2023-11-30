using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStore.Api.Features.CompactDisks.ViewModels;
using MusicStore.DB.DataAccess;

namespace MusicStore.Api.Features.CompactDisks.Action
{
    public class GetListCompactDisks
    {
        public class Query : IRequest<CDViweModel[]>
        { }
        
        public class Handler : IRequestHandler<Query, CDViweModel[]>
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

            public async Task<CDViweModel[]> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.CompactDisks
                    .ProjectTo<CDViweModel>(_mapper.ConfigurationProvider)
                    .ToArrayAsync(cancellationToken);

                return result;
            }
        }
    }
}
