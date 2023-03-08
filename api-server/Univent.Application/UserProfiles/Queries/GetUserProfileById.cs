using MediatR;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.Queries
{
    public class GetUserProfileById : IRequest<UserProfile>
    {
        public Guid UserProfileID { get; set; }
    }
}
