using MediatR;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.Events.Queries
{
    public class GetAvailableEvents : IRequest<IEnumerable<Event>>
    {
    }
}
