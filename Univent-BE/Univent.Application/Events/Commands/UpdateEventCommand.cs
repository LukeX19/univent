using MediatR;

namespace Univent.Application.Events.Commands
{
    public class UpdateEventCommand : IRequest
    {
        public Guid EventID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaximumParticipants { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
