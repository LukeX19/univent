using MediatR;

namespace Univent.Application.Events.Commands
{
    public class DeleteEventCommand : IRequest
    {
        public Guid EventID { get; set; }
    }
}
