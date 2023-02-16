using MediatR;

namespace Univent.Application.Universities.Commands
{
    public class UpdateUniversityCommand : IRequest
    {
        public Guid UniversityID { get; set; }
        public string Name { get; set; }
    }
}
