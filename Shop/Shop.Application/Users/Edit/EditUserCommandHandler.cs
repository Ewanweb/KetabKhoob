using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Edit;

internal class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserDomainService _userDomainsService;
    private readonly IFileService _fileService;

    public EditUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService, IFileService fileService)
    {
        _userRepository = userRepository;
        _userDomainsService = userDomainService;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);

        if (user is null)
            return OperationResult.NotFound();

        var oldAvatar = user.AvatarName;

        user.Edit(request.Name, request.Family, request.PhoneNumber, request.Email, request.Gender, _userDomainsService);

        if (request.Avatar != null)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.Avatar, Directories.UserAvatars);
                
            user.SetAvatar(imageName);
        }

        DeleteOldAvatar(request.Avatar, oldAvatar);
        await _userRepository.Save();

        return OperationResult.Success();
    }

    private void DeleteOldAvatar(IFormFile? avatarFile, string oldAvatar)
    {
        if (avatarFile is null || oldAvatar is "noImage.png")
            return;
            
        _fileService.DeleteFile(Directories.UserAvatars, oldAvatar);
    }
}