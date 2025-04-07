using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Sellers.Create
{
    public record CreateSellerCommand(long UserId, string ShopName, string NationalCode) : IBaseCommand;
}
