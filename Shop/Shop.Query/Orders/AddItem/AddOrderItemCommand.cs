using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Orders.AddItem
{
    public record AddOrderItemCommand(long InventoryId, int Count, long UserId) : IBaseCommand;
}
