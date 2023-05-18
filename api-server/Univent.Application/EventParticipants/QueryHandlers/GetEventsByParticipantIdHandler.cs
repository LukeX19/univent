using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.EventParticipants.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventParticipants.QueryHandlers
{
    internal class GetEventsByParticipantIdHandler :IRequestHandler<GetEventsByParticipantId, IEnumerable<Event>>
    {
        private readonly DataContext _dbcontext;

        public GetEventsByParticipantIdHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Event>> Handle(GetEventsByParticipantId request, CancellationToken cancellationToken)
        {
            var eventParticipants = await _dbcontext.EventParticipants
                .Where(ep => ep.UserProfileID == request.UserProfileID)
                .ToListAsync(cancellationToken);

            var eventIds = eventParticipants.Select(ep => ep.EventID).ToList();

            var events = await _dbcontext.Events
                .Where(e => eventIds.Contains(e.EventID))
                .ToListAsync(cancellationToken);

            return events;
        }
    }
}
