//using Dapper;
//using Microsoft.EntityFrameworkCore;
//using Shop.Domain.SellerAgg;
//using Shop.Domain.SellerAgg.Repository;
//using Shop.Infrastructure._Utilities;

//namespace Shop.Infrastructure.Persistent.Ef.SellerAgg;

//internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
//{
//    private readonly ShopContext _context;
//    public SellerRepository(ShopContext context) : base(context)
//    {
//        _context = context;
//    }
//    public async Task<InventoryResult?> GetInventoryById(long id)
//    {
//        return await _context.Inventories.Where(r => r.Id == id)
//            .Select(i => new InventoryResult()
//            {
//                Count = i.Count,
//                Id = i.Id,
//                Price = i.Price,
//                ProductId = i.ProductId,
//                SellerId = i.SellerId
//            }).FirstOrDefaultAsync();
//    }

//}