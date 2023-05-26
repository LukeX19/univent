using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Exceptions;
using Univent.Application.UserProfiles.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;
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

            //Get all events created by user
            var userEvents = await _dbcontext.Events.Where(e => e.UserProfileID == request.UserProfileID).ToListAsync(cancellationToken);
            foreach (var userEvent in userEvents)
            {
                //Delete all participants for every event created by this user, as those Events will be automatically deleted
                var eventParticipants = await _dbcontext.EventParticipants
                    .Where(ep => ep.EventID == userEvent.EventID)
                    .ToListAsync(cancellationToken);

                _dbcontext.EventParticipants.RemoveRange(eventParticipants);
            }

            //Get all participations for this User in other events
            var thisUserParticipations = await _dbcontext.EventParticipants
                .Where(ep => ep.UserProfileID == request.UserProfileID)
                .ToListAsync(cancellationToken);
            _dbcontext.EventParticipants.RemoveRange(thisUserParticipations);

            _dbcontext.UserProfiles.Remove(userProfile);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            await _userManager.DeleteAsync(identityUser);

            return new Unit();
        }
    }
}
