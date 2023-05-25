using MediatR;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.Queries
{
    public class GetUnapprovedUserProfiles : IRequest<IEnumerable<UserProfile>>
    {
    }
}
