using System.ComponentModel.DataAnnotations;

namespace Univent.Api.Contracts.ValidationAttributes
{
    public class EndTimeAfterStartTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var endTime = (DateTime)value;
            var startTimeProperty = validationContext.ObjectType.GetProperty("StartTime");
            var startTime = (DateTime)startTimeProperty.GetValue(validationContext.ObjectInstance, null);

            if (endTime <= startTime)
            {
                return new ValidationResult("End time must be after start time");
            }

            return ValidationResult.Success;
        }
    }
}
