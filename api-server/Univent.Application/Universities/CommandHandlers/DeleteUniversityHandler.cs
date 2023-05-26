using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Exceptions;
using Univent.Application.Universities.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Application.Universities.CommandHandlers
{
    internal class DeleteUniversityHandler : IRequestHandler<DeleteUniversityCommand>
    {
        private readonly DataContext _dbcontext;

        public DeleteUniversityHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteUniversityCommand request, CancellationToken cancellationToken)
        {
            // Get University
            var university = await _dbcontext.Universities.FirstOrDefaultAsync(u => u.UniversityID == request.UniversityID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(University), request.UniversityID);

            //Get the Affected User Profiles from this University
            var affectedUsers = await _dbcontext.UserProfiles.Where(up => up.UniversityID == request.UniversityID).ToListAsync(cancellationToken);

            foreach (var affectedUser in affectedUsers)
            {
                //Get all events created by user
                var userEvents = await _dbcontext.Events.Where(e => e.UserProfileID == affectedUser.UserProfileID).ToListAsync(cancellationToken);
                foreach (var userEvent in userEvents)
                {
                    //Delete all participants for every event created by this user, as those Events will be automatically deleted
                    var eventParticipants = await _dbcontext.EventParticipants
                        .Where(ep => ep.EventID == userEvent.EventID)
                        .ToListAsync(cancellationToken);

                    _dbcontext.EventParticipants.RemoveRange(eventParticipants);
                }

                //Get all participations for this User in other events and delete them
                var thisUserParticipations = await _dbcontext.EventParticipants
                    .Where(ep => ep.UserProfileID == affectedUser.UserProfileID)
                    .ToListAsync(cancellationToken);
                _dbcontext.EventParticipants.RemoveRange(thisUserParticipations);
            }

            // Get the IdentityIDs of the affected users
            var identityIds = affectedUsers.Select(up => up.IdentityID).ToList();

            // Delete University
            _dbcontext.Universities.Remove(university);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            // Delete identity users associated with the Identity IDs
            var usersToDelete = await _dbcontext.Users.Where(u => identityIds.Contains(u.Id)).ToListAsync(cancellationToken);
            _dbcontext.Users.RemoveRange(usersToDelete);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
