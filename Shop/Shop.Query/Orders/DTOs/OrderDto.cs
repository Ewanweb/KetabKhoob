using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.OrderAgg;
using Shop.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Common.Query.Filter;
using Shop.Domain.ProductAgg;

namespace Shop.Query.Orders.DTOs
{
    public class OrderDto : BaseDto
    {
        public long UserId { get;  set; }
        public string UserFullName { get;  set; }
        public OrderStatus Status { get;  set; }
        public OrderDiscount? Discount { get;  set; }
        public OrderAddress? Address { get;  set; }
        public ShippingMethod? ShippingMethod { get;  set; }
        public List<OrderItemDto> Items { get;  set; }
        public DateTime? LastUpdate { get;  set; }
    }

    public class OrderItemDto : BaseDto
    {
        public string ProductTitle { get; set; }
        public string ProductSlug { get; set; }
        public string ProductImageName { get; set; }
        public string ShopName { get; set; }
        public long OrderId { get; set; }
        public long InventoryId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int TotalPrice => Price * Count;
    }


    public class OrderFilterDataDto : BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public OrderStatus Status { get; set; }
        public string? Shire { get; set; }
        public string? City { get; set; }
        public string? ShippingType { get; set; }
        public int TotalPrice { get; set; }
        public int TotalItemCount { get; set; }
    }

    public class OrderFilterParams : BaseFilterParam
    {
        public long? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public OrderStatus? Status { get; set; }
    }

    public class OrderFilterResult : BaseFilter<OrderFilterDataDto, OrderFilterParams>
    {

    }
}
