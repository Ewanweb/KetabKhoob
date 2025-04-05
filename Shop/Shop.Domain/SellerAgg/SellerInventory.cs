using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg;

public class SellerInventory : BaseEntity
{

    public long SellerId { get; internal set; }
    public long ProductId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int? PercentageDiscount { get; private set; }

    public SellerInventory(long productId, int count, int price, int? percentageDiscount)
    {
        if (price < 1 || count < 0)
            throw new InvalidDomainDataException();

        ProductId = productId;
        Count = count;
        Price = price;
        PercentageDiscount = percentageDiscount;
    }

    public void Edit(int count, int price, int? percentageDiscount)
    {
        if (price < 1 || count < 0)
            throw new InvalidDomainDataException();

        Count = count;
        Price = price;
        PercentageDiscount = percentageDiscount;
    }
}