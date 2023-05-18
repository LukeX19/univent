using MediatR;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.EventParticipants.Queries
{
    public class GetParticipantsByEventId : IRequest<IEnumerable<UserProfile>>
    {
        public Guid EventID { get; set; }
    }
}
