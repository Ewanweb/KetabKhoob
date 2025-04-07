using Common.Domain.Repository;
using Shop.Domain.SiteEntities.Banner;

namespace Shop.Domain.UserAgg.Repository;

public interface IUserRepository : IBaseRepository<User>
{
    UserAddress GetAddressById(long addressId);
}