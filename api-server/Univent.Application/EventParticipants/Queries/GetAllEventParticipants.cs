using MediatR;
using Univent.Domain.Aggregates.EventAggregate;

namespace Univent.Application.EventParticipants.Queries
{
    public class GetAllEventParticipants : IRequest<IEnumerable<EventParticipant>>
    {
    }
}
