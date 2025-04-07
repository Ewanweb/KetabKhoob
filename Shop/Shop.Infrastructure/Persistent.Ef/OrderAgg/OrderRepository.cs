using Microsoft.EntityFrameworkCore;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly ShopContext _context;
        public OrderRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public Task<Order?> GetCurrentOrder(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> GetCurrentUserOrder(long userId)
        {
            return await _context.Orders.AsTracking().FirstOrDefaultAsync(f => f.UserId == userId
                                                                               && f.Status == OrderStatus.Pending);
        }

       
    }
}