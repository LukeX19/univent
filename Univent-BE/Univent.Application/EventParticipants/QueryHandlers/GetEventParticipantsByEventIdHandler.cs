using MediatR;
using Microsoft.EntityFrameworkCore;
using Univent.Application.EventParticipants.Queries;
using Univent.Dal;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventParticipants.QueryHandlers
{
    internal class GetEventParticipantsByEventIdHandler : IRequestHandler<GetEventParticipantsByEventId, IEnumerable<EventParticipant>>
    {
        private readonly DataContext _dbcontext;

        public GetEventParticipantsByEventIdHandler(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<EventParticipant>> Handle(GetEventParticipantsByEventId request, CancellationToken cancellationToken)
        {
            return await _dbcontext.EventParticipants
                .Where(ep => ep.EventID == request.EventID)
                .ToListAsync();
        }
    }
}
