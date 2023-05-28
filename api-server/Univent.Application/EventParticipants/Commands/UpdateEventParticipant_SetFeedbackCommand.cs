using MediatR;

namespace Univent.Application.EventParticipants.Commands
{
    public class UpdateEventParticipant_SetFeedbackCommand : IRequest
    {
        public Guid EventID { get; set; }
        public Guid UserProfileID { get; set; }
    }
}
