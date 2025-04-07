using Common.Application.Validation;
using FluentValidation;
using Shop.Application.Comments.ChangeStatus;

namespace Shop.Application.Comments.Edit;

public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
{
    public EditCommentCommandValidator()
    {
        RuleFor(r => r.Text)
            .NotNull().WithMessage(ValidationMessages.required("توضیحات"))
            .MinimumLength(5).WithMessage(ValidationMessages.minLength("توضیحات", 5));
    }
}