using MediatR;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.Events.Queries
{
    public class GetEventsByUserId : IRequest<IEnumerable<Event>>
    {
        public Guid UserProfileID { get; set; }
    }
}
