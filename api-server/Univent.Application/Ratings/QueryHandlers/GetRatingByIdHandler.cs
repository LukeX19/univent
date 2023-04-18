using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Exceptions;
using Univent.Application.Ratings.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.Ratings.QueryHandlers
{
    internal class GetRatingByIdHandler : IRequestHandler<GetRatingById, Rating>
    {
        private readonly DataContext _dbcontext;

        public GetRatingByIdHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Rating> Handle(GetRatingById request, CancellationToken cancellationToken)
        {
            var rating = await _dbcontext.Ratings.FirstOrDefaultAsync(r => r.RatingID == request.RatingID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(Rating), request.RatingID);

            return rating;
        }
    }
}
