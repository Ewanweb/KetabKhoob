﻿using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Banners;

namespace Shop.Application.SiteEntities.Banners.Create;

public class CreateBannerCommandHandler : IBaseCommandHandler<CreateBannerCommand>
{

    private readonly IBannerRepository _bannerRepository;
    private readonly IFileService _fileService;

    public CreateBannerCommandHandler(IBannerRepository bannerRepository, IFileService fileService)
    {
        _bannerRepository = bannerRepository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannersImages);

        var banner = new Banner(request.Link, imageName, request.Position);

        await _bannerRepository.AddAsync(banner);
        await _bannerRepository.Save();
        return OperationResult.Success();
    }
}