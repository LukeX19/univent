using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.EventParticipants.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventParticipants.QueryHandlers
{
    internal class GetEventsByParticipantIdHandler :IRequestHandler<GetEventsByParticipantId, IEnumerable<EventParticipant>>
    {
        private readonly DataContext _dbcontext;

        public GetEventsByParticipantIdHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<EventParticipant>> Handle(GetEventsByParticipantId request, CancellationToken cancellationToken)
        {
            var events = await _dbcontext.EventParticipants
                .Where(ep => ep.UserProfileID == request.UserProfileID)
                .ToListAsync(cancellationToken);

            return events;
        }
    }
}
