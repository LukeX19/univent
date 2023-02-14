using MediatR;

namespace Univent.Application.UserProfiles.Commands
{
    public class DeleteUserProfileCommand : IRequest
    {
        public Guid UserProfileId { get; set; }
    }
}
