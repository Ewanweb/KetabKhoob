using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Banner;

namespace Shop.Application.SiteEntities.Banners.Create;

public class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
{

    private readonly IBannerRepository _bannerRepository;
    private readonly IFileService _fileService;

    public EditBannerCommandHandler(IBannerRepository bannerRepository, IFileService fileService)
    {
        _bannerRepository = bannerRepository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _bannerRepository.GetTracking(request.Id);

        if (banner is null )
            return OperationResult.NotFound();

        var imageName = banner.ImageName;

        if (request.ImageFile != null)
        {
            _fileService.DeleteFile(Directories.BannersImages, imageName);
            imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannersImages);
        }

        banner.Edit(request.Link, imageName, request.Position);

        await _bannerRepository.Save();
        return OperationResult.Success();
    }
}