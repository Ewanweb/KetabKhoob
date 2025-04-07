using FluentValidation;

namespace Shop.Application.Users.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(r => r.Password)
            .NotNull().WithMessage("رمز عبور نمی تواند خالی باشد")
            .NotEmpty().WithMessage("رمز عبور نمی تواند خالی باشد")
            .MinimumLength(4).WithMessage("رمز عبور باید حداقل 4 کاراکتر باشد");
    }
}