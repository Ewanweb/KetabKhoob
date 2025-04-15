using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Shop.Domain.RoleAgg;

namespace Shop.Query.Roles.GetById
{
    public record GetRoleByIdQuery(long RoleId) : IQuery<RoleDto?>;
}
