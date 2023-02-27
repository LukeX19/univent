using MediatR;
using Univent.Application.Ratings.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.Ratings.CommandHandlers
{
    internal class CreateRatingHandler : IRequestHandler<CreateRatingCommand, Rating>
    {
        private readonly DataContext _dbcontext;
        public CreateRatingHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Rating> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = Rating.CreateRating(request.UserProfileID, request.Value);

            _dbcontext.Ratings.Add(rating);
            await _dbcontext.SaveChangesAsync();

            return rating;
        }
    }
}
