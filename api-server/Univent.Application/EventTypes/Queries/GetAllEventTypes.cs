using MediatR;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventTypes.Queries
{
    public class GetAllEventTypes : IRequest<IEnumerable<EventType>>
    {
    }
}
