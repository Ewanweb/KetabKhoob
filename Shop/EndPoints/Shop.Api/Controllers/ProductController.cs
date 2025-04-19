using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Presentation.Facade.Comments;
using Shop.Presentation.Facade.Products;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.GetById;

namespace Shop.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductFacade _productFacade;

        public ProductController(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }

        [HttpGet]
        public async Task<ApiResult<ProductFilterResult>> GetProductByFilter([FromQuery] ProductFilterParams filterParams)
        {
            var result = await _productFacade.GetProductsByFilter(filterParams);
            return QueryResult(result);
        }

        [HttpGet("{productId}")]
        public async Task<ApiResult<ProductDto?>> GetProductById(long productId)
        {
            var result = await _productFacade.GetProductById(productId);
            return QueryResult(result);
        }

        [HttpGet("{slug}")]
        public async Task<ApiResult<ProductDto?>> GetProductBySlug(string slug)
        {
            var result = await _productFacade.GetProductBySlug(slug);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> CreateProduct([FromForm]CreateProductCommand command)
        {
            var result = await _productFacade.CreateProduct(command);
            return CommandResult(result);
        }

        [HttpPost("AddImages")]
        public async Task<ApiResult> AddImages([FromForm] AddProductImageCommand command)
        {
            var result = await _productFacade.AddImage(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditProduct([FromForm]EditProductCommand command)
        {
            var result = await _productFacade.EditProduct(command);

            return CommandResult(result);
        }

        [HttpDelete("RemoveImage")]
        public async Task<ApiResult> RemoveImage(RemoveProductImageCommand command)
        {
            var result = await _productFacade.RemoveImage(command);

            return CommandResult(result);
        }
    }
}
