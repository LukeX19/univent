using MediatR;
using Univent.Application.Models;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.Queries
{
    public class GetAllUserProfiles : IRequest<OperationResult<IEnumerable<UserProfile>>>
    {
    }
}
