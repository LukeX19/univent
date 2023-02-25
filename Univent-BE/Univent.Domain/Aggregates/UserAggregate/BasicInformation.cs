using Univent.Domain.Exceptions;
using Univent.Domain.Validators.UserProfileValidators;

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

        //Constructor
        private BasicInformation()
        {
        }

        public static BasicInformation CreateBasicInformation(string firstName, string lastName, string emailAddress,
            string phoneNumber, DateTime dateOfBirth, string hometown)
        {
            var validator = new BasicInformationValidator();

            var newBasicInformation = new BasicInformation
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber,
                DateOfBirth = dateOfBirth,
                Hometown = hometown
            };

            var validationResult = validator.Validate(newBasicInformation);

            if(validationResult.IsValid)
                return newBasicInformation;

            var exception = new UserProfileNotValidException("The User Profile is not valid");
            foreach(var error in validationResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }
            throw exception;
        }
    }
}
