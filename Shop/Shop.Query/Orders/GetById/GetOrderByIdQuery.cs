using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetById
{
    public record GetOrderByIdQuery(long OrderId) : IQuery<OrderDto?>;


    public class GetOrderByIdQueryHandler(ShopContext context, DapperContext dapper)
        : IQueryHandler<GetOrderByIdQuery, OrderDto?>
    {
        private readonly ShopContext _context = context;
        private readonly DapperContext _dapper = dapper;

        public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(f => f.Id == request.OrderId,
                cancellationToken: cancellationToken);

            if (order is null)
                return null!;

            var orderDto = order.Map();

            orderDto.UserFullName = await _context.Users.Where(u => u.Id == orderDto.UserId)
                .Select(s => $"{s.Name} {s.Family}").FirstAsync(cancellationToken: cancellationToken);

            orderDto.Items = await orderDto.GetOrderItem(_dapper);

            return orderDto;
        }
    }
}
