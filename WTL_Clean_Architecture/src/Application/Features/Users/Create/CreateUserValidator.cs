using Application.Helpers;
using Application.Models;
using FluentValidation;

namespace Application.Features.Users.Create
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("RoleId is required")
                .Must((roleId) => CheckValidationHelper.IsIntOrLong(roleId));
            RuleFor(x => x.Email).NotNull().WithMessage("Email is required")
                .NotEmpty().WithMessage("Email not empty")
                .EmailAddress().WithMessage("Invalid email address");
            RuleFor(x => x.Password).NotNull().WithMessage("Password is required")
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(8).WithMessage("Password must be at least 8 character");
            RuleFor(x => x.RePassword).NotNull().WithMessage("RePassword is required")
                .NotEmpty().WithMessage("RePassword cannot be empty")
                .Equal(x => x.Password).WithMessage("Passwords do not match")
                .MinimumLength(8).WithMessage("RePassword must be at least 8 character");
            When(x => !string.IsNullOrEmpty(x.PhoneNumber), () =>
            {
                RuleFor(x => x.PhoneNumber)
                    .Matches(RegexHelper.PhoneNumberRegexVietNam).WithMessage("Invalid phone number format");
            });

            When(x => !string.IsNullOrEmpty(x.FullName), () =>
            {
                RuleFor(x => x.FullName)
                    .Must((fullName) => CheckValidationHelper.IsNullOrDefault(fullName))
                    .WithMessage("FullName cannot be empty");
            });

            When(x => !string.IsNullOrEmpty(x.Address), () =>
            {
                RuleFor(x => x.Address)
                    .Must((address) => CheckValidationHelper.IsNullOrDefault(address))
                    .WithMessage("Address cannot be empty");
            });

            //When(x => x.Gender.HasValue, () =>
            //{
            //    RuleFor(x => x.Gender)
            //        .Must((gender) => CheckValidationHelper.IsNullOrDefault(gender))
            //        .WithMessage("Gender cannot be empty");
            //});
        }
    }
}
