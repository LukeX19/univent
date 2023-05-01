using System.ComponentModel.DataAnnotations;

namespace Univent.Api.Contracts.ValidationAttributes
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var birthDate = (DateTime)value;
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (age < 18 || age > 26)
            {
                return new ValidationResult("Age should be between 18 and 26 years old.");
            }

            return ValidationResult.Success;
        }
    }
}
