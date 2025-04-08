using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Comments.DTOs;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetByFilter
{
    public class GetOrdersByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
    {
        public GetOrdersByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
