using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Shop.Domain.RoleAgg;

namespace Shop.Query.Roles
{
    public class RoleDto() : BaseDto
    {
        public string Title { get; set; }
        public List<Permission> Permissions { get; set; }
    }

}
