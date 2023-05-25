using MediatR;

namespace Univent.Application.UserProfiles.Commands
{
    public class UpdateUserProfile_ApproveComand : IRequest
    {
        public Guid UserProfileID { get; set; }
    }
}
