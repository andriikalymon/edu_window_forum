using FluentValidation;
using Forum.Domain.ViewModels.User;

namespace Forum.Domain.FluentValidation.User
{
    public class AuthenticateUserViewModelValidator : AbstractValidator<AuthenticateUserViewModel>
    {
        public AuthenticateUserViewModelValidator()
        {
            RuleFor(user => user.Email)
                .NotNull().WithMessage("Email is required")
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email address is not valid");
            RuleFor(user => user.Password)
                .NotNull().WithMessage("Password is required")
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(5).WithMessage("Password length should be greater than 4")
                .MaximumLength(16).WithMessage("Password length should be less than 17");
        }
    }
}
