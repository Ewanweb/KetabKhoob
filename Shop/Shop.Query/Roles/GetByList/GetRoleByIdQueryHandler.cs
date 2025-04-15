using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;

namespace Shop.Query.Roles.GetByList;

public class GetRoleByIdQueryHandler(ShopContext context) : IQueryHandler<GetRoleListQuery, List<RoleDto>>
{
    private readonly ShopContext _context = context;
    public async Task<List<RoleDto>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.Select(role => new RoleDto()
        {
            Id = role.Id,
            CreationDate = role.CreationDate,
            Title = role.Title,
            Permissions = role.Permissions.Select(s => s.Permission).ToList()
        }).ToListAsync(cancellationToken : cancellationToken);


        return role;
    }
}