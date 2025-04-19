using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Addresses.GetByList
{
    public record GetUserAddressesListQuery(long UserId) : IQuery<List<AddressDto>>;
}
