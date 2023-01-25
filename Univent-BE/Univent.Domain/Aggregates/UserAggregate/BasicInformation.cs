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
        public Guid UniversityID { get; private set; }
        public University UniversityInfo { get; private set; }
        public UniversityYear Year { get; private set; }

        //Constructor
        private BasicInformation()
        {
        }

        private static BasicInformation CreateBasicInformation(string firstName, string lastName, string emailAddress,
            string phoneNumber, DateTime dateOfBirth, string hometown, Guid chosenUniversityID, UniversityYear chosenYear)
        {
            //TO DO: add validation and error handling
            var newBasicInformation = new BasicInformation
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber,
                DateOfBirth = dateOfBirth,
                Hometown = hometown,
                UniversityID = chosenUniversityID,
                Year = chosenYear
            };

            return newBasicInformation;
        }
    }
}
