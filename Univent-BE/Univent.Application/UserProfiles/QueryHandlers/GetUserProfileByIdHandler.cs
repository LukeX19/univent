using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.UserProfiles.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.QueryHandlers
{
    internal class GetUserProfileByIdHandler : IRequestHandler<GetUserProfileById, UserProfile>
    {
        private readonly DataContext _dbcontext;

        public GetUserProfileByIdHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<UserProfile> Handle(GetUserProfileById request, CancellationToken cancellationToken)
        {
            return await _dbcontext.UserProfiles.FirstOrDefaultAsync(up => up.UserID == request.UserProfileID);
        }
    }
}
