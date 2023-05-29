using MediatR;
using Univent.Application.DTOs;

namespace Univent.Application.Events.Queries
{
    public class GetAllEvents : IRequest<IEnumerable<EventReadModel>>
    {
    }
}
