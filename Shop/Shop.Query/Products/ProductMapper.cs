using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products
{
    public static class ProductMapper
    {
        public static ProductDto? Map(this Product? product)
        {
            if (product is null)
                return null;
            
            return new ProductDto()
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                Description = product.Description,
                ImageName = product.ImageName,
                Slug = product.Slug,
                Title = product.Title,
                SeoData = product.SeoData,
                Specifications = product.Specifications.Select(x => new ProductSpecificationDto()
                {
                    Key = x.Key,
                    Value = x.Value
                }).ToList(),
                Images = product.Images.Select(x => new ProductImageDto()
                {
                    Id = x.Id,
                    ImageName = x.ImageName,
                    ProductId = x.ProductId,
                    Sequence = x.Sequence,
                    CreationDate = x.CreationDate,
                }).ToList(), 
                Category = new () {Id = product.CategoryId},
                SubCategory = new () {Id = product.SubCategoryId},
                SecondaryCategory = product.SecondarySubCategoryId != null ? new () {Id = (long)product.SecondarySubCategoryId} : null,
            };
        }

        public static ProductFilterDataDto MapListData(this Product product)
        {
            return new ProductFilterDataDto()
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                ImageName = product.ImageName,
                Slug = product.Slug,
                Title = product.Title,
            };
        }

        public static async Task SetCategories(this ProductDto product, ShopContext context)
        {
            var category = await context.Categories
                .Where(f => f.Id == product.Category.Id)
                .Select(s => new ProductCategoryDto()
                {
                    Id = s.Id,
                    Slug = s.Slug,
                    Title = s.Title,
                    ParentId = s.ParentId,
                    SeoData = s.SeoData
                })
                .FirstOrDefaultAsync(x => x.Id == product.Category.Id);

            var subCategory = await context.Categories
                .Where(f => f.Id == product.SubCategory.Id)
                .Select(s => new ProductCategoryDto()
                {
                    Id = s.Id,
                    Slug = s.Slug,
                    Title = s.Title,
                    ParentId = s.ParentId,
                    SeoData = s.SeoData
                })
                .FirstOrDefaultAsync(x => x.Id == product.SubCategory.Id);

            if (product.SecondaryCategory is not null)
            {
                var secondaryCategory = await context.Categories
                    .Where(f => f.Id == product.SubCategory.Id)
                    .Select(s => new ProductCategoryDto()
                    {
                        Id = s.Id,
                        Slug = s.Slug,
                        Title = s.Title,
                        ParentId = s.ParentId,
                        SeoData = s.SeoData
                    })
                    .FirstOrDefaultAsync(x => x.Id == product.Category.Id);
               
                if (secondaryCategory is not null)
                    product.Category = secondaryCategory;

            }

            if (category is not null)
                product.Category = category;

            if (subCategory is not null)
                product.Category = subCategory;

            return product;
        }
    }
}
