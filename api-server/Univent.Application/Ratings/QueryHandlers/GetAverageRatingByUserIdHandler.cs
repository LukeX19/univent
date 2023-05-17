using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Ratings.Queries;
using Univent.Dal;

namespace Univent.Application.Ratings.QueryHandlers
{
    internal class GetAverageRatingByUserIdHandler : IRequestHandler<GetAverageRatingByUserId, double>
    {
        private readonly DataContext _dbcontext;

        public GetAverageRatingByUserIdHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<double> Handle(GetAverageRatingByUserId request, CancellationToken cancellationToken)
        {
            var ratings = await _dbcontext.Ratings
                .Where(r => r.UserProfileID == request.UserProfileID)
                .ToListAsync(cancellationToken);

            if(ratings.Any())
            {
                double average = ratings.Average(r => r.Value);
                return Math.Round(average, 2);
            }

            return 0;
        }
    }
}
