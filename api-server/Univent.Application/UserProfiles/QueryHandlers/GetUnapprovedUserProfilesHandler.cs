using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.UserProfiles.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.QueryHandlers
{
    internal class GetUnapprovedUserProfilesHandler : IRequestHandler<GetUnapprovedUserProfiles, IEnumerable<UserProfile>>
    {
        private readonly DataContext _dbcontext;

        public GetUnapprovedUserProfilesHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<UserProfile>> Handle(GetUnapprovedUserProfiles request, CancellationToken cancellationToken)
        {
            return await _dbcontext.UserProfiles.Where(up => up.isAccountConfirmed == false).ToListAsync(cancellationToken);
        }
    }
}
