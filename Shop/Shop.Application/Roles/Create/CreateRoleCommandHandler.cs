using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Application.Roles.Create;

public class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
            return OperationResult.Error("عنوان نقش نمی‌تواند خالی باشد.");

        var permissions = request.Permissions?
            .Select(p => new RolePermission(p))
            .ToList() ?? new List<RolePermission>();

        var role = new Role(request.Title, permissions);

        try
        {
            await _roleRepository.AddAsync(role);
            await _roleRepository.Save();
            return OperationResult.Success();
        }
        catch (Exception ex)
        {
            return OperationResult.Error($"خطا در ایجاد نقش: {ex.Message}");
        }
    }
}