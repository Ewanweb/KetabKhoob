using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Addresses.GetById
{
    public record GetUserAddressByIdQuery(long AddressId) : IQuery<AddressDto?>;
}
