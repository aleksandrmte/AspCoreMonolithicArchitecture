using FluentValidation;

namespace Web.Feature.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(v => v.Email)
                .EmailAddress()
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(30).WithMessage("Email must not exceed 30 characters.");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MaximumLength(12).WithMessage("Password must not exceed 12 characters.");
        }
    }
}
