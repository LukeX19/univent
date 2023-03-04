using MediatR;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventParticipants.Queries
{
    public class GetEventParticipantsByEventId : IRequest<IEnumerable<EventParticipant>>
    {
        public Guid EventID { get; set; }
    }
}
