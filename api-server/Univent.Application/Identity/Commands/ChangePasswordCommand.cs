using MediatR;

namespace Univent.Application.Identity.Commands
{
    public class ChangePasswordCommand : IRequest
    {
        public string UserID { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
