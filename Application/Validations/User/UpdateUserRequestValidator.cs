using Application.Dtos.User;
using FluentValidation;

namespace Application.Validations.User;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(user => user.Email)
            .EmailAddress()
            .MaximumLength(40);
        RuleFor(user => user.Name).MaximumLength(18);
    }
}