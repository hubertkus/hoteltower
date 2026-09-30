
using FluentValidation;

namespace User.RegisterUser;

public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be not empty");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email must be not empty");
    }
}