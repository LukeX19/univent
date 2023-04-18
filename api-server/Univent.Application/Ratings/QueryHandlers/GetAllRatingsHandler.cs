using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Ratings.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.Ratings.QueryHandlers
{
    internal class GetAllRatingsHandler : IRequestHandler<GetAllRatings, IEnumerable<Rating>>
    {
        private readonly DataContext _dbcontext;

        public GetAllRatingsHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Rating>> Handle(GetAllRatings request, CancellationToken cancellationToken)
        {
            return await _dbcontext.Ratings.ToListAsync(cancellationToken);
        }
    }
}
