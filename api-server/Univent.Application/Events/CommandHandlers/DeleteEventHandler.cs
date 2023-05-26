using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Events.Commands;
using Univent.Application.Exceptions;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.Events.CommandHandlers
{
    internal class DeleteEventHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly DataContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteEventHandler(DataContext dbcontext, UserManager<IdentityUser> userManager)
        {
            _dbcontext = dbcontext;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var _event = await _dbcontext.Events.FirstOrDefaultAsync(e => e.EventID == request.EventID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(Event), request.EventID);

            var userProfile = await _dbcontext.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileID == request.UserProfileID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(UserProfile), request.UserProfileID);
            var identity = await _userManager.FindByIdAsync(userProfile.IdentityID);
            var userRole = await _userManager.GetRolesAsync(identity);

            if (_event.UserProfileID != request.UserProfileID && !userRole.Contains("Admin"))
            {
                throw new EventDeleteNotPossibleException();
            }

            var eventParticipants = await _dbcontext.EventParticipants
                .Where(ep => ep.EventID == request.EventID)
                .ToListAsync(cancellationToken);

            _dbcontext.EventParticipants.RemoveRange(eventParticipants);
            _dbcontext.Events.Remove(_event);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
