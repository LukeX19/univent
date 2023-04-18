using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.UserProfiles.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.QueryHandlers
{
    internal class GetAllUserProfilesHandler : IRequestHandler<GetAllUserProfiles, IEnumerable<UserProfile>>
    {
        private readonly DataContext _dbcontext;

        public GetAllUserProfilesHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfiles request,
            CancellationToken cancellationToken)
        {
            return await _dbcontext.UserProfiles.ToListAsync(cancellationToken);
        }
    }
}
