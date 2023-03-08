using MediatR;

namespace Univent.Application.EventTypes.Commands
{
    public class DeleteEventTypeCommand : IRequest
    {
        public Guid EventTypeID { get; set; }
    }
}
