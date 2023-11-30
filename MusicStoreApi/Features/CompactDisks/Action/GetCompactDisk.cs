using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStore.Api.Features.CompactDisks.ViewModels;
using MusicStore.DB.DataAccess;

namespace MusicStore.Api.Features.CompactDisks.Action
{
    public class GetCompactDisk
    {
        public class Query : IRequest<CDViweModel>
        {
            public Guid MusicId { get; set; }
        }

        public class QuerValidator : AbstractValidator<Query>
        {
            public QuerValidator(MusicStoreDbContext dbContext)
            {
                RuleFor(x => x.MusicId)
                    .MustAsync(async (musicId, cancellationToken) =>
                    {
                        var compactDisk = await dbContext.CompactDisks
                        .FirstOrDefaultAsync(
                            compactDisk => compactDisk.MusicId == musicId,
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
                     .Where(x => x.MusicId == request.MusicId)
                     .ProjectTo<CDViweModel>(_mapper.ConfigurationProvider)
                     .FirstAsync(cancellationToken);

                return a;
            }
        }
    }
}