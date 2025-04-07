using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SiteEntities;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg;

internal class ShippingMethodRepository : BaseRepository<ShippingMethod>, IShippingMethodRepository
{
    private readonly ShopContext _context;
    public ShippingMethodRepository(ShopContext context) : base(context)
    {
        _context = context;
    }

    public void Delete(ShippingMethod slider)
    {
        _context.ShippingMethods.Remove(slider);
    }
}