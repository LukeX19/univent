using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.Exceptions;
using Univent.Application.UserProfiles.Commands;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.CommandHandlers
{
    internal class UpdateUserProfile_ApproveHandler : IRequestHandler<UpdateUserProfile_ApproveComand>
    {
        private readonly DataContext _dbcontext;

        public UpdateUserProfile_ApproveHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateUserProfile_ApproveComand request, CancellationToken cancellationToken)
        {
            var _profile = await _dbcontext.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileID == request.UserProfileID, cancellationToken)
                ?? throw new ObjectNotFoundException(nameof(UserProfile), request.UserProfileID);

            _profile.ApproveUser();

            _dbcontext.Update(_profile);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
