using MediatR;
using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Application.Universities.Queries
{
    public class GetUniversityById : IRequest<University>
    {
        public Guid UniversityID { get; set; }
    }
}
