using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Users.DeleteUserAddress
{
    public record DeleteUserAddressCommand(long UserId, long AddressId) : IBaseCommand;
}
