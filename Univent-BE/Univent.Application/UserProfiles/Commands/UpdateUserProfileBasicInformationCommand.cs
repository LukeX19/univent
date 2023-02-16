using MediatR;

namespace Univent.Application.UserProfiles.Commands
{
    public class UpdateUserProfileBasicInformationCommand : IRequest
    {
        public Guid UserProfileID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Hometown { get; set; }
    }
}
