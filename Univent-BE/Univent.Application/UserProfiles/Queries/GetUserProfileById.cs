using MediatR;
using Univent.Application.Models;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.Queries
{
    public class GetUserProfileById : IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileID { get; set; }
    }
}
