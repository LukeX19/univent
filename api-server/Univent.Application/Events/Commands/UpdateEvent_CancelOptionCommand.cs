using MediatR;

namespace Univent.Application.Events.Commands
{
    public class UpdateEvent_CancelOptionCommand : IRequest
    {
        public Guid EventID { get; set; }
        public string? CancellationReason { get; set; }
    }
}
