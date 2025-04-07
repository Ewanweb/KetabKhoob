using FluentValidation;
using Shop.Application.Orders.IncreaseItemCount;

namespace Shop.Application.Orders.DecreaseItemCount;

public class DecreaseOrderItemCountCommandValidator : AbstractValidator<IncreaseOrderItemCountCommand>
{
    public DecreaseOrderItemCountCommandValidator()
    {
        RuleFor(r => r.Count)
            .GreaterThanOrEqualTo(1).WithMessage("تعداد نباید کمتر یا برار 0 باشد");
    }
}