using MediatR;

namespace Univent.Application.EventParticipants.Commands
{
    public class DeleteEventParticipantCommand : IRequest
    {
        public Guid EventID { get; set; }
        public Guid UserProfileID { get; set; }
    }
}
