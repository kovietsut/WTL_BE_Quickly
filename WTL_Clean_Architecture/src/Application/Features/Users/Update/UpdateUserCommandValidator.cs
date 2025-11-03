using FluentValidation;

namespace Application.Features.Users.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.RoleId).NotEmpty();
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email is required")
                .NotEmpty().WithMessage("Email not empty")
                .EmailAddress().WithMessage("Invalid email address");
            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("Phone number is required")
                .NotEmpty().WithMessage("Phone number cannot be empty");
        }
    }
}


