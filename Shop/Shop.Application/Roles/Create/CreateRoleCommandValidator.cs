using FluentValidation;

namespace Shop.Application.Roles.Create;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotEmpty()
            .WithMessage("عنوان نقش را وارد کنید")
            .MaximumLength(100)
            .WithMessage("عنوان نقش نمی تواند بیشتر از 100 کاراکتر باشد");
    }
}