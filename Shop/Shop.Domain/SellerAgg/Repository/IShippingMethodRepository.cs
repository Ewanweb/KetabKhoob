using Common.Domain.Repository;
using Shop.Domain.SiteEntities;

namespace Shop.Domain.SellerAgg.Repository;

public interface IShippingMethodRepository : IBaseRepository<ShippingMethod>
{
    void Delete(ShippingMethod method);
}