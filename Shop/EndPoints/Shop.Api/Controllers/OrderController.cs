using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.CheackOut;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Presentation.Facade.Comments;
using Shop.Presentation.Facade.Orders;
using Shop.Query.Comments.DTOs;
using Shop.Query.Orders.DTOs;

namespace Shop.Api.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderFacade _orderFacade;

        public OrderController(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        [HttpGet]
        public async Task<ApiResult<OrderFilterResult>> GetOrderByFilter([FromQuery] OrderFilterParams filterParams)
        {
            var result = await _orderFacade.GetOrdersByFilter(filterParams);
            return QueryResult(result);
        }

        [HttpGet("{orderId}")]
        public async Task<ApiResult<OrderDto?>> GetOrderById(long orderId)
        {
            var result = await _orderFacade.GetOrderById(orderId);

            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> AddOrderItem(AddOrderItemCommand command)
        {
            var result = await _orderFacade.AddOrderItem(command);

            return CommandResult(result);
        }

        [HttpPost("CheckOut")]
        public async Task<ApiResult> CheckOut(CheckOutOrderCommand command)
        {
            var result = await _orderFacade.OrderCheckOut(command);
            return CommandResult(result);
        }

        [HttpPut("OrderItem/IncreaseOrderItemCount")]
        public async Task<ApiResult> IncreaseOrderItemCount(IncreaseOrderItemCountCommand command)
        {
            var result = await _orderFacade.IncreaseItemCount(command);

            return CommandResult(result);
        }

        [HttpPut("OrderItem/DecreaseOrderItemCount")]
        public async Task<ApiResult> DecreaseOrderItemCount(DecreaseOrderItemCountCommand command)
        {
            var result = await _orderFacade.DecreaseItemCount(command);

            return CommandResult(result);
        }

        [HttpDelete("OrderItem")]
        public async Task<ApiResult> DeleteOrderItem(RemoveOrderItemCommand command)
        {
            var result = await _orderFacade.RemoveOrderItem(command);

            return CommandResult(result);
        }
    }
}
