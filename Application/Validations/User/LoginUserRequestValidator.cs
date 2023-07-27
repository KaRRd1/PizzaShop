using Application.Dtos.User;
using FluentValidation;

namespace Application.Validations.User;

public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
{
    public LoginUserRequestValidator()
    {
        RuleFor(user => user.Phone)
            .Matches(@"^\+7 \(\d{3}\) \d{3}-\d{2}-\d{2}$")
            .WithMessage("Incorrect format. Should be '+7 (xxx) xxx-xx-xx'");
        
        
    }
}