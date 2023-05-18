using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Univent.Application.EventParticipants.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.EventParticipants.QueryHandlers
{
    internal class GetParticipantsByEventIdHandler : IRequestHandler<GetParticipantsByEventId, IEnumerable<UserProfile>>
    {
        private readonly DataContext _dbcontext;

        public GetParticipantsByEventIdHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<UserProfile>> Handle(GetParticipantsByEventId request, CancellationToken cancellationToken)
        {
            var eventParticipants = await _dbcontext.EventParticipants
                .Where(ep => ep.EventID == request.EventID)
                .ToListAsync(cancellationToken);

            var userIds = eventParticipants.Select(ep => ep.UserProfileID).ToList();

            var users = await _dbcontext.UserProfiles
                .Where(e => userIds.Contains(e.UserProfileID))
                .ToListAsync(cancellationToken);

            return users;
        }
    }
}
