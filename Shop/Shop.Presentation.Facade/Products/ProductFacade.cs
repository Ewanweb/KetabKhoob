using Common.Application;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.GetByFilter;
using Shop.Query.Products.GetById;
using Shop.Query.Products.GetBySlug;

namespace Shop.Presentation.Facade.Products;

internal class ProductFacade : IProductFacade
{
    private readonly IMediator _mediator;
    private readonly IDistributedCache _cache;
    //private readonly ISellerInventoryFacade _inventoryFacade;
    public ProductFacade(IMediator mediator, IDistributedCache cache /* ISellerInventoryFacade inventoryFacade*/)
    {
        _mediator = mediator;
        _cache = cache;
        //_inventoryFacade = inventoryFacade;
    }

    public async Task<OperationResult> CreateProduct(CreateProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditProduct(EditProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> AddImage(AddProductImageCommand command)
    {
        var result = await _mediator.Send(command);
        return result;
    }

    public async Task<OperationResult> RemoveImage(RemoveProductImageCommand command)
    {
        var result = await _mediator.Send(command);

        return result;
    }

    public async Task<ProductDto?> GetProductById(long productId)
    {
        return await _mediator.Send(new GetProductByIdQuery(productId));
    }

    public async Task<ProductDto?> GetProductBySlug(string slug)
    {
        return await _mediator.Send(new GetProductBySlugQuery(slug));
    }

    //public async Task<SingleProductDto?> GetProductBySlugForSinglePage(string slug)
    //{
    //    return await _cache.GetOrSet(CacheKeys.Product(slug), async () =>
    //    {
    //        var product = await _mediator.Send(new GetProductBySlugQuery(slug));
    //        if (product == null)
    //            return null;

    //        var inventories = await _inventoryFacade.GetByProductId(product.Id);
    //        var model = new SingleProductDto()
    //        {
    //            Inventories = inventories,
    //            ProductDto = product
    //        };
    //        return model;
    //    });
    //}

    public async Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams)
    {
        return await _mediator.Send(new GetProductByFilterQuery(filterParams));
    }

    //public async Task<ProductShopResult> GetProductsForShop(ProductShopFilterParam filterParams)
    //{
    //    return await _mediator.Send(new GetProductsForShopQuery(filterParams));
    //}
}