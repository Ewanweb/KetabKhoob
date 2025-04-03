using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Application;
using FluentValidation;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Application.Roles.Edit
{
    public record EditRoleCommand(long Id, string Title, List<Permission> Permissions) : IBaseCommand;

    public class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public EditRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return OperationResult.Error("عنوان نقش نمی‌تواند خالی باشد.");

            var role = await _roleRepository.GetTracking(request.Id);

            if (role is null)
                return OperationResult.NotFound();

            role.Edit(request.Title);

            var permissions = request.Permissions?
                .Select(p => new RolePermission(p))
                .ToList() ?? new List<RolePermission>();

            role.SetPermissions(permissions);

            try
            {
                await _roleRepository.Save();
                return OperationResult.Success();
            }
            catch (Exception ex)
            {
                return OperationResult.Error($"خطا در تغییر نقش: {ex.Message}");
            }
        }
    }

    public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
    {
        public EditRoleCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty()
                .WithMessage("عنوان نقش را وارد کنید")
                .MaximumLength(100)
                .WithMessage("عنوان نقش نمی تواند بیشتر از 100 کاراکتر باشد");
        }
    }
}