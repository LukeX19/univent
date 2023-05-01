using System.ComponentModel.DataAnnotations;

namespace Univent.Api.Contracts.ValidationAttributes
{
    public class RatingCustomDoubleValueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double input = Convert.ToDouble(value);

            if (input < 0 || input > 5 || (input * 10) % 5 != 0)
            {
                return new ValidationResult("Rating value must be between 0 and 5, and can only be with .0 or .5 increments");
            }

            return ValidationResult.Success;
        }
    }
}
