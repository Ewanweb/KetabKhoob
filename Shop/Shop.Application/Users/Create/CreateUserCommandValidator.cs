using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {

        RuleFor(r => r.Email)
            .EmailAddress().WithMessage("ایمیل نامعتبر است");

        RuleFor(r => r.Password)
            .NotNull().WithMessage("رمز عبور نمی تواند خالی باشد")
            .NotEmpty().WithMessage("رمز عبور نمی تواند خالی باشد")
            .MinimumLength(4).WithMessage("رمز عبور باید حداقل 4 کاراکتر باشد");
    }
}