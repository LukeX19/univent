using MediatR;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventTypes.Commands
{
    public class CreateEventTypeCommand : IRequest<EventType>
    {
        public string Name { get; set; }
    }
}
