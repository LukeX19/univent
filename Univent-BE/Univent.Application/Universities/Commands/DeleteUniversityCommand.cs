using MediatR;

namespace Univent.Application.Universities.Commands
{
    public class DeleteUniversityCommand : IRequest
    {
        public Guid UniversityID { get; set; }
    }
}
