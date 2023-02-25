using FluentValidation;
using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Domain.Validators.UserProfileValidators
{
    public class BasicInformationValidator : AbstractValidator<BasicInformation>
    {
        public BasicInformationValidator()
        {
            RuleFor(info => info.FirstName)
                .NotNull().WithMessage("First name is required! It is currently null")
                .MinimumLength(3).WithMessage("First name must contain at least 3 characters")
                .MaximumLength(50).WithMessage("First name can have a maximum of 50 characters");
        
            RuleFor(info => info.LastName)
                .NotNull().WithMessage("Last name is required! It is currently null")
                .MinimumLength(3).WithMessage("Last name must contain at least 3 characters")
                .MaximumLength(50).WithMessage("Last name can have a maximum of 50 characters");

            RuleFor(info => info.EmailAddress)
                .NotNull().WithMessage("Email address is required! It is currently null")
                .EmailAddress().WithMessage("Provided information does not have a correct email address format");

            RuleFor(info => info.DateOfBirth)
                //.NotNull().WithMessage("Date of birth is required! It is currently null")
                .InclusiveBetween(new DateTime(DateTime.Now.AddYears(-26).Ticks), new DateTime(DateTime.Now.AddYears(-18).Ticks))
                .WithMessage("Age must be between 18 and 26 years old");
        }
    }
}
