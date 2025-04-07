using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Dapper;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg;

internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
{
    private readonly ShopContext _context;
    private readonly DapperContext _dapper;
    public SellerRepository(ShopContext context) : base(context)
    {
        _context = context;
    }
    public async Task<InventoryResult?> GetInventoryById(long id)
    {
        using var connection = _dapper.CreateConnection();
        var sql = $"SELECT * FROM {_dapper.Inventories} where Id = @id";

        return await connection.QueryFirstOrDefaultAsync<InventoryResult>(sql, new {Id = id});
    }

}