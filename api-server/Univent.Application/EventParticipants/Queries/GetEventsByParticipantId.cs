using MediatR;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventParticipants.Queries
{
    public class GetEventsByParticipantId : IRequest<IEnumerable<Event>>
    {
        public Guid UserProfileID { get; set; }
    }
}
