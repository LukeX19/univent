using MediatR;
using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Application.Universities.Queries
{
    public class GetAllUniversities : IRequest<IEnumerable<University>>
    {
    }
}
