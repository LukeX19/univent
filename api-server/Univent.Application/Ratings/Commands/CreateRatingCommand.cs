using MediatR;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.Ratings.Commands
{
    public class CreateRatingCommand : IRequest<Rating>
    {
        public Guid UserProfileID { get; set; }
        public double Value { get; set; }
    }
}
