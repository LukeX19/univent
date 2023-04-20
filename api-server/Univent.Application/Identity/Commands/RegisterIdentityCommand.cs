using MediatR;
using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Application.Identity.Commands
{
    public class RegisterIdentityCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid UniversityID { get; set; }
        public UniversityYear Year { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Hometown { get; set; }
    }
}
