using MediatR;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventParticipants.Queries
{
    public class GetEventsByParticipantId : IRequest<IEnumerable<EventParticipant>>
    {
        public Guid UserProfileID { get; set; }
    }
}
