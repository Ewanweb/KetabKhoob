using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Sellers.AddInventory
{
    public record AddSellerInventoryCommand(long SellerId, long ProductId, int Count, int Price, int? PercentageDiscount) : IBaseCommand;
}
