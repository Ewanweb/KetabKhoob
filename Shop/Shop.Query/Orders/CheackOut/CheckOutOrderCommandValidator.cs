using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.CheackOut;

public class CheckOutOrderCommandValidator : AbstractValidator<CheckOutOrderCommand>
{
    public CheckOutOrderCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().NotNull()
            .WithMessage(ValidationMessages.required("نام"));

        RuleFor(r => r.Family)
            .NotEmpty().NotNull()
            .WithMessage(ValidationMessages.required("نام خانوادگی"));

        RuleFor(r => r.City)
            .NotEmpty().NotNull()
            .WithMessage(ValidationMessages.required("شهر"));

        RuleFor(r => r.PostalAddress)
            .NotEmpty().NotNull()
            .WithMessage(ValidationMessages.required("شهر"));

        RuleFor(r => r.PostalCode)
            .NotEmpty().NotNull()
            .WithMessage(ValidationMessages.required("کد پستی"));

        RuleFor(r => r.Shire)
            .NotEmpty().NotNull()
            .WithMessage(ValidationMessages.required("ادرس"));

        RuleFor(r => r.Nationalcode)
            .NotEmpty().NotNull()
            .WithMessage(ValidationMessages.required("کدملی"))
            .MaximumLength(10).WithMessage("کدملی نا معتبر است")
            .MinimumLength(10).WithMessage("کدملی نا معتبر است")
            .ValidNationalId();

        RuleFor(r => r.PhoneNumber)
            .NotEmpty().NotNull()
            .WithMessage(ValidationMessages.required("شماره موبایل"))
            .MaximumLength(11)
            .MinimumLength(11).WithMessage("شماره موبایل نا معتبر است");
    }
}