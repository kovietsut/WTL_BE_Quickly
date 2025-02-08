using Application.Helpers;
using Application.Models;
using FluentValidation;

namespace Application.Features.Users.Commands
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("RoleId is required")
                .Must((roleId) => CheckValidationHelper.IsIntOrLong(roleId));
            RuleFor(x => x.Email).NotNull().WithMessage("Email is required")
                .NotEmpty().WithMessage("Email not empty")
                .EmailAddress().WithMessage("Invalid email address");
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Phone number is required")
                .NotEmpty().WithMessage("Phone number cannot be empty")
                .Matches(RegexHelper.PhoneNumberRegexVietNam).WithMessage("Invalid phone number format");
            RuleFor(x => x.FullName).Must((fullName) => CheckValidationHelper.IsNullOrDefault(fullName))
                .WithMessage("FullName cannot be empty");
            RuleFor(x => x.Address).Must((address) => CheckValidationHelper.IsNullOrDefault(address))
                .WithMessage("Address cannot be empty");
            RuleFor(x => x.Gender).Must((gender) => CheckValidationHelper.IsNullOrDefault(gender))
                .WithMessage("Gender cannot be empty");
        }
    }
}
