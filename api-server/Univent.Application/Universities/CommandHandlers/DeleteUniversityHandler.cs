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

            //Get the Affected Users from this University
            var affectedUsers = await _dbcontext.UserProfiles.Where(up => up.UniversityID == request.UniversityID).ToListAsync(cancellationToken);

            // Get the IdentityIDs of the affected users
            var identityIds = affectedUsers.Select(up => up.IdentityID).ToList();

            // Delete University
            _dbcontext.Universities.Remove(university);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            // Delete users associated with the IdentityIDs
            var usersToDelete = await _dbcontext.Users.Where(u => identityIds.Contains(u.Id)).ToListAsync(cancellationToken);
            _dbcontext.Users.RemoveRange(usersToDelete);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
