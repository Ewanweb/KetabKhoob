﻿using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.ProductDomainService;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.Edit;

public class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
{
    private readonly IProductDomainService _domainService;
    private readonly IProductRepository _repository;
    private readonly IFileService _fileService;

    public EditProductCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService fileService)
    {
        _domainService = domainService;
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetTracking(request.ProductId);

        if (product is null)
            return OperationResult.NotFound();

        product.Edit(request.Title, request.Description, request.CategoryId, request.SubCategoryId, request.SecondarySubCategoryId, request.Slug, request.SeoData, _domainService);

        var oldImage = product.ImageName;


        if (request.ImageFile is not null)
        {
            var imageName =
                await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
                    
            product.SerProductImage(imageName);
        }

        var specifications = new List<ProductSpecification>();

        request.Specifications.ToList().ForEach(specification =>
        {
            specifications.Add(new ProductSpecification(specification.Key, specification.Value));
        });
        product.SetSpecification(specifications);

        await _repository.Save();

        RemoveOldImage(request.ImageFile, oldImage);

        return OperationResult.Success();

    }

    private void RemoveOldImage(IFormFile? imageFile, string oldImage)
    {
        if (imageFile is not null)
        {
            _fileService.DeleteFile(Directories.ProductImages, oldImage);
        }
    }
}