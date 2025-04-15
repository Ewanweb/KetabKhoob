using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;

namespace Shop.Query.Roles.GetById;

public class GetRoleByIdQueryHandler(ShopContext context) : IQueryHandler<GetRoleByIdQuery, RoleDto?>
{
    private readonly ShopContext _context = context;
    public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(f => f.Id == request.RoleId, cancellationToken : cancellationToken );

        if (role is null)
            return null;

        return new RoleDto()
        {
            Id = role.Id,
            CreationDate = role.CreationDate,
            Title = role.Title,
            Permissions = role.Permissions.Select(s => s.Permission).ToList()
        };
    }
}