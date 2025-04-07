using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.EditUserAddress;

public class EditUserAddressCommandValidator : AbstractValidator<EditUserAddressCommand>
{
    public EditUserAddressCommandValidator()
    {
        RuleFor(r => r.City)
            .NotEmpty().WithMessage(ValidationMessages.required("شهر"));

        RuleFor(r => r.Shire)
            .NotEmpty().WithMessage(ValidationMessages.required("استان"));

        RuleFor(r => r.Family)
            .NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));

        RuleFor(r => r.Nationalcode)
            .NotEmpty().WithMessage(ValidationMessages.required("کد ملی"))
            .ValidNationalId();

        RuleFor(r => r.City)
            .NotEmpty().WithMessage(ValidationMessages.required("شهر"));

        RuleFor(r => r.PostalAddress)
            .NotEmpty().WithMessage(ValidationMessages.required("ادرس پستی"));

        RuleFor(r => r.PostalCode)
            .NotEmpty().WithMessage(ValidationMessages.required("کد پستی"));
    }
}