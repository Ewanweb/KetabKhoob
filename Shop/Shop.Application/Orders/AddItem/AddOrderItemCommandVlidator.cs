using FluentValidation;

namespace Shop.Application.Orders.AddItem;

public class AddOrderItemCommandVlidator : AbstractValidator<AddOrderItemCommand>
{
    public AddOrderItemCommandVlidator()
    {
        RuleFor(r => r.Count)
            .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}