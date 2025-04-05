﻿using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Slider;

namespace Shop.Application.SiteEntities.Sliders.Create;

public class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
{

    private readonly ISliderRepository _sliderRepository;
    private readonly IFileService _fileService;

    public CreateSliderCommandHandler(ISliderRepository sliderRepository, IFileService fileService)
    {
        _sliderRepository = sliderRepository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SlidersImages);

        var slider = new Slider(request.Title, request.Link, imageName);

        await _sliderRepository.AddAsync(slider);
        await _sliderRepository.Save();
        return OperationResult.Success();
    }
}