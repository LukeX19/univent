using MediatR;

namespace Univent.Application.EventTypes.Commands
{
    public class UpdateEventTypeCommand : IRequest
    {
        public Guid EventTypeID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }
}
