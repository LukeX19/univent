using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Exceptions;
using Univent.Application.UserProfiles.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.CommandHandlers
{
    internal class DeleteUserProfileHandler : IRequestHandler<DeleteUserProfileCommand>
    {
        private readonly DataContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteUserProfileHandler(DataContext dbcontext, UserManager<IdentityUser> userManager)
        {
            _dbcontext = dbcontext;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _dbcontext.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileID == request.UserProfileID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(UserProfile), request.UserProfileID);

            var identityUser = await _userManager.FindByEmailAsync(userProfile.BasicInfo.EmailAddress);
            if (identityUser == null)
            {
                throw new IdentityUserNotFoundException(userProfile.BasicInfo.EmailAddress);
            }

            _dbcontext.UserProfiles.Remove(userProfile);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            await _userManager.DeleteAsync(identityUser);

            return new Unit();
        }
    }
}
