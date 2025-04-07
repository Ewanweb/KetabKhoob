using Common.Domain.Repository;

namespace Shop.Domain.UserAgg.Repository;

public interface IUserRepository : IBaseRepository<User>
{
    UserAddress GetAddressById(long addressId);
}