using MediatR;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventTypes.Queries
{
    public class GetEventTypeById : IRequest<EventType>
    {
        public Guid EventTypeID { get; set; }
    }
}
