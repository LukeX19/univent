using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Ratings.Commands;
using Univent.Dal;

namespace Univent.Application.Ratings.CommandHandlers
{
    internal class DeleteRatingHandler : IRequestHandler<DeleteRatingCommand>
    {
        private readonly DataContext _dbcontext;

        public DeleteRatingHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = await _dbcontext.Ratings.FirstOrDefaultAsync(r => r.RatingID == request.RatingID);

            _dbcontext.Ratings.Remove(rating);
            await _dbcontext.SaveChangesAsync();

            return new Unit();
        }
    }
}
