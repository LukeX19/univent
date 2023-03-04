using MediatR;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventParticipants.Queries
{
    public class GetEventParticipantByBothIds : IRequest<EventParticipant>
    {
        public Guid EventID { get; set; }
        public Guid UserProfileID { get; set; }
    }
}
