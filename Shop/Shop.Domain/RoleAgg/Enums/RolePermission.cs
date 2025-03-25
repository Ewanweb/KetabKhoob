using Common.Domain;

namespace Shop.Domain.RoleAgg.Enums;

public class RolePermission : BaseEntity
{
    public long RoleId { get; private set; }
    public Permission Permission { get; private set; }
}