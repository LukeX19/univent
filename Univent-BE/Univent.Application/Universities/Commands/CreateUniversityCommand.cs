using MediatR;
using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Application.Universities.Commands
{
    public class CreateUniversityCommand : IRequest<University>
    {
        public string Name { get; set; }
    }
}
