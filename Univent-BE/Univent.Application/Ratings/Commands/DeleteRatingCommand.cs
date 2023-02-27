using MediatR;

namespace Univent.Application.Ratings.Commands
{
    public class DeleteRatingCommand : IRequest
    {
        public Guid RatingID { get; set; }
    }
}
