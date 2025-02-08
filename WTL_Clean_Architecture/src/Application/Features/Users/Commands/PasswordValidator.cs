using Application.Models;
using FluentValidation;

namespace Application.Features.Users.Commands
{
    public class PasswordValidator : AbstractValidator<PasswordDto>
    {
        public PasswordValidator()
        {
            RuleFor(x => x.CurrentPassword).NotNull().NotEmpty().WithMessage("Current password cannot be empty");
            RuleFor(x => x.NewPassword).NotNull().NotEmpty().WithMessage("New password cannot be empty")
                .MinimumLength(8).WithMessage("Password length at least 8");
            RuleFor(x => x.ConfirmPassword).NotNull().NotEmpty().WithMessage("Confirm password password cannot be empty")
                .Equal(x => x.NewPassword).WithMessage("New password does not match new password")
                .MinimumLength(8).WithMessage("Password length at least 8");
        }
    }
}
