using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStore.DB.DataAccess;
using MusicStore.DB.Models;

namespace MusicStore.Api.Features.CompactDisks.Action
{
    public class CreateCompactDisk
    {
        public class Query : IRequest
        {
            public Guid MusicId { get; set; }

            public Guid ManufactoringCompanyId { get; set; }

            public decimal RetailPrice { get; set; }

            public decimal WholeSalePrice { get; set; }

            public int CountInStock { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                
            }
        }


        public class Handler : IRequestHandler<Query>
        {
            private readonly MusicStoreDbContext _dbContext;

            public Handler(MusicStoreDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task Handle(Query request, CancellationToken cancellationToken)
            {
                var music = await _dbContext.Musics
                    .SingleAsync(
                        x => x.Id == request.MusicId,
                        cancellationToken);

                var manufactoringCompany = await _dbContext.ManufacturingCompanies
                    .SingleAsync(
                        x => x.Id == request.ManufactoringCompanyId,
                        cancellationToken);

                var compactDisk = new CompactDisk(
                    music: music,
                    manufacturingCompany: manufactoringCompany,
                    retailPrice: request.RetailPrice,
                    whosalerPrice: request.WholeSalePrice,
                    countInStock: request.CountInStock);

                await _dbContext.CompactDisks.AddAsync(compactDisk, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}