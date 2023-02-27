using MediatR;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.Ratings.Queries
{
    public class GetRatingById : IRequest<Rating>
    {
        public Guid RatingID { get; set; }
    }
}
