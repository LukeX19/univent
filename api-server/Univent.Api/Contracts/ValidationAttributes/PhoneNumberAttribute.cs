using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Univent.Api.Contracts.ValidationAttributes
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        private readonly Regex _regex;

        public PhoneNumberAttribute()
        {
            _regex = new Regex(@"^\+?\d{10,14}$"); // Matches a phone number with country code (optional) and between 10 and 14 digits
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!_regex.IsMatch(value.ToString()))
            {
                return new ValidationResult("Invalid phone number format");
            }

            return ValidationResult.Success;
        }
    }
}
