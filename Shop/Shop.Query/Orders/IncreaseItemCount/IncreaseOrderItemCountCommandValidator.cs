using FluentValidation;

namespace Shop.Application.Orders.IncreaseItemCount;

public class IncreaseOrderItemCountCommandValidator : AbstractValidator<IncreaseOrderItemCountCommand>
{
    public IncreaseOrderItemCountCommandValidator()
    {
        RuleFor(r => r.Count)
            .GreaterThanOrEqualTo(1).WithMessage("تعداد نباید کمتر یا برار 0 باشد");
    }
}