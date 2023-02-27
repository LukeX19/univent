using MediatR;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.Ratings.Queries
{
    public class GetAllRatings : IRequest<IEnumerable<Rating>>
    {
    }
}
