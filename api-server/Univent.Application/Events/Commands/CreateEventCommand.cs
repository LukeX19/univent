using MediatR;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.Events.Commands
{
    public class CreateEventCommand : IRequest<Event>
    {
        public Guid UserProfileID { get; set; }
        public Guid EventTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaximumParticipants { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double LocationLat { get; set; }
        public double LocationLng { get; set; }
    }
}
