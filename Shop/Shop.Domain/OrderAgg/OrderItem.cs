﻿using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg;

public class OrderItem : BaseEntity
{
    public OrderItem(long inventoryId, int count, int price)
    {
        PriceGuard(price);
        CountGuard(count);
        InventoryId = inventoryId;
        Count = count;
        Price = price;
    }
    public long OrderId { get; internal set; }
    public long InventoryId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int TotalPrice => Count * Price;

    public void IncreaseCount(int count)
    {
        Count += count;
    }

    public void DecreaseCount(int count)
    {
        if (Count is 1 || Count - count <= 0)
            return;

        Count -= count;
    }

    public void ChangeCount(int newCount)
    {
        CountGuard(newCount);

        Count = newCount;
    }

    public void SetPrice(int newPrice)
    {
        PriceGuard(newPrice);
        Price = newPrice;
    }


    public void PriceGuard(int newPrice)
    {
        if (newPrice < 1)
            throw new InvalidDomainDataException("مبلغ کالا نامعتبر است");
    }

    public void CountGuard(int newCount)
    {
        if (newCount < 1)
            throw new InvalidDomainDataException("تعداد کالا نامعتبر است");
    }
}