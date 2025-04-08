using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders
{
    internal static class OrderMapper
    {
        public static OrderDto Map(this Order order)
        {
            return new OrderDto()
            {
                Id = order.Id,
                CreationDate = order.CreationDate,
                Status = order.Status,
                Address = order.Address,
                Discount = order.Discount,
                Items = new(),
                LastUpdate = order.LastUpdate,
                ShippingMethod = order.ShippingMethod,
                UserFullName = "",
                UserId = order.UserId
            };
        }

        public static async Task<List<OrderItemDto>> GetOrderItem(this OrderDto orderDto, DapperContext dapper)
        {
            using var connection = dapper.CreateConnection();

            var sql = $"SELECT s.ShopName ,o.OrderId , o.InventoryId, o.Count, o.Price," +
                      $" p.Title as [Product.Title], p.Slug as [Product.Slug], p.ImageName as [Product.ImageName]" +
                      $" FROM{dapper.OrderItems} o" +
                      $" Inner Join {dapper.Inventories} i on o.InventoryId=i.Id" +
                      $" Inner Join {dapper.Products} p on i.ProductId=p.Id" +
                      $" Inner Join {dapper.Sellers} s on i.SellerId=s.Id" +       
                      $" where o.OrderId=@orderId";

            var result = await connection.QueryAsync<OrderItemDto>(sql, new {orderId = orderDto.Id});

            return result.ToList();
        }

        public static OrderFilterDataDto MapFilterData(this Order order, ShopContext context)
        {
            var userFullName = context.Users.Where(r => r.Id == order.UserId)
                .Select(u => $"{u.Name} {u.Family}").First();


            return new OrderFilterDataDto()
            {
                Id = order.Id,
                CreationDate = order.CreationDate,
                Status = order.Status,
                City = order.Address?.City,
                Shire = order.Address?.Shire,
                TotalItemCount = order.ItemCount,
                TotalPrice = order.TotalPrice,
                ShippingType = order.ShippingMethod?.ShippingTypes,
                UserFullName = userFullName,
                UserId = order.UserId
            };
        }
    }
}
