using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.UserProfiles.Commands;
using Univent.Dal;

namespace Univent.Application.UserProfiles.CommandHandlers
{
    internal class DeleteUserProfileHandler : IRequestHandler<DeleteUserProfileCommand>
    {
        private readonly DataContext _dbcontext;

        public DeleteUserProfileHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _dbcontext.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileID == request.UserProfileID);

            /*if (userProfile is null)
            {
                return new Unit();
            }*/

            _dbcontext.UserProfiles.Remove(userProfile);
            await _dbcontext.SaveChangesAsync();

            return new Unit();
        }
    }
}
