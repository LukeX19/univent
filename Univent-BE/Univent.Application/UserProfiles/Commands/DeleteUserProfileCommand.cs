using MediatR;
using Univent.Application.Models;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.Commands
{
    public class DeleteUserProfileCommand : IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileID { get; set; }
    }
}
