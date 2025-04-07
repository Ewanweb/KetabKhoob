using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Create;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(r => r.Text)
            .NotNull().WithMessage(ValidationMessages.required("توضیحات"))
            .MinimumLength(5).WithMessage(ValidationMessages.minLength("توضیحات", 5));
    }
}