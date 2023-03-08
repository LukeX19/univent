using MediatR;
using Univent.Domain.Aggregates.UniversityAggregate;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Application.UserProfiles.Commands
{
    public class CreateUserCommand : IRequest<UserProfile>
    {
        public Guid UniversityID { get; set; }
        public UniversityYear Year { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Hometown { get; set; }
    }
}
