using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories
{
    internal static class CategoryMapper
    {
        public static CategoryDto Map(this Category? category)
        {
            if (category is null)
                return null!;

            return new CategoryDto()
            {
                Title = category.Title,
                Slug = category.Slug,
                SeoData = category.SeoData,
                Id = category.Id,
                CreationDate = category.CreationDate,
                Childs = category.Childs.MapChild()
            };
        }

        public static List<CategoryDto> Map(this List<Category> categories)
        {
            var model = new List<CategoryDto>();

            categories.ForEach(category =>
            {
                model.Add(new CategoryDto()
                {
                    Title = category.Title,
                    Slug = category.Slug,
                    SeoData = category.SeoData,
                    Id = category.Id,
                    CreationDate = category.CreationDate,
                    Childs = category.Childs.MapChild()
                });
            });

            return model;
        }


        public static List<ChildCategoryDto> MapChild(this List<Category> childCategories)
        {
            var model = new List<ChildCategoryDto>();

            childCategories.ForEach(c =>
            {
                model.Add(new ChildCategoryDto()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Slug = c.Slug,
                    CreationDate = c.CreationDate,
                    ParentId = (long)c.ParentId!,
                    Childs = c.Childs.MapSecondaryChild()
                });
            });

            return model;
        }

        private static List<SecondaryCategoryDto> MapSecondaryChild(this List<Category> childCategories)
        {
            var model = new List<SecondaryCategoryDto>();

            childCategories.ForEach(c =>
            {
                model.Add(new SecondaryCategoryDto()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Slug = c.Slug,
                    CreationDate = c.CreationDate,
                    ParentId = (long)c.ParentId!,
                });
            });

            return model;
        }
    }
}
