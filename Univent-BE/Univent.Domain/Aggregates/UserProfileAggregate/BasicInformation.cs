using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univent.Domain.Aggregates.UserProfileAggregate
{
    public class BasicInformation
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Hometown { get; private set; }

        //Constructor
        private BasicInformation()
        {
        }

        private static BasicInformation CreateBasicInformation(string firstName, string lastName, string emailAddress,
            string phoneNumber, DateTime dateOfBirth, string hometown)
        {
            //TO DO: add validation and error handling

            var basicInformation = new BasicInformation
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress= emailAddress,
                PhoneNumber= phoneNumber,
                DateOfBirth= dateOfBirth,
                Hometown= hometown
            };

            return basicInformation;
        }
    }
}
