using Univent.Domain.Aggregates.UniversityAggregate;

namespace Univent.Domain.Aggregates.UserAggregate
{
    public class BasicInformation
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Hometown { get; private set; }
        public string ProfilePicture { get; private set; }

        //Constructor
        private BasicInformation()
        {
        }

        public static BasicInformation CreateBasicInformation(string firstName, string lastName, string emailAddress,
            string phoneNumber, DateTime dateOfBirth, string hometown, string profilePicture)
        {
            var newBasicInformation = new BasicInformation
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber,
                DateOfBirth = dateOfBirth,
                Hometown = hometown,
                ProfilePicture = profilePicture
            };

            return newBasicInformation;
        }
    }
}
