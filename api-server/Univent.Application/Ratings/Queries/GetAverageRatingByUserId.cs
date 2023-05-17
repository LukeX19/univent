using MediatR;

namespace Univent.Application.Ratings.Queries
{
    public class GetAverageRatingByUserId : IRequest<double>
    {
        public Guid UserProfileID { get; set; }
    }
}
