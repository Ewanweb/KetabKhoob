using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using FluentValidation;

namespace Shop.Application.Sellers.EditInventory
{
    public record EditInventoryCommand(long SellerId, long InventoryId, int Count, int Price, int? PercentageDiscount) : IBaseCommand;
}
