using Common.Domain;

namespace Shop.Domain.RoleAgg.Enums;

public class RolePermission : BaseEntity
{
    public RolePermission(Permission permission)
    {
        Permission = permission;
    }
    public long RoleId { get; internal set; }
    public Permission Permission { get; private set; }
}