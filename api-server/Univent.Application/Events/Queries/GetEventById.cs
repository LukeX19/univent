using MediatR;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.Events.Queries
{
    public class GetEventById : IRequest<Event>
    {
        public Guid EventID { get; set; }
    }
}
