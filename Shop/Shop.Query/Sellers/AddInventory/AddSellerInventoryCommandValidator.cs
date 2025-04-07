using FluentValidation;

namespace Shop.Application.Sellers.AddInventory;

public class AddSellerInventoryCommandValidator : AbstractValidator<AddSellerInventoryCommand>
{
    public AddSellerInventoryCommandValidator()
    {
        RuleFor(x => x.SellerId).NotEmpty().WithMessage("فروشنده نمی تواند خالی باشد");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("محصول نمی تواند خالی باشد");
        RuleFor(x => x.Count).GreaterThan(0).WithMessage("تعداد نمی تواند کمتر از 1 باشد");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("قیمت نمی تواند کمتر از 1 باشد");
    }
}