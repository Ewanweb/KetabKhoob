using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Roles.GetByList
{
    public record GetRoleListQuery() : IQuery<List<RoleDto>>;
}
