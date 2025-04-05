using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Slider;

namespace Shop.Application.SiteEntities.Sliders.Edit;

public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
{

    private readonly ISliderRepository _sliderRepository;
    private readonly IFileService _fileService;

    public EditSliderCommandHandler(ISliderRepository sliderRepository, IFileService fileService)
    {
        _sliderRepository = sliderRepository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
    {
        var slider = await _sliderRepository.GetTracking(request.Id);

        if (slider is null)
            return OperationResult.NotFound();

        var imageName = slider.ImageName;

        if (request.ImageFile != null)
        {
            _fileService.DeleteFile(Directories.SlidersImages, imageName);
            imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SlidersImages);
        }

        slider.Edit(request.Title, request.Link, imageName);

        await _sliderRepository.Save();
        return OperationResult.Success();
    }
}