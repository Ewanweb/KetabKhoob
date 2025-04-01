using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utilities;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.ProductDomainService;

namespace Shop.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {
        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public string SecondarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }

        private Product()
        {

        }

        public Product(string title, string imageName, string description, long categoryId, long subCategoryId,
            string secondarySubCategoryId, string slug, SeoData seoData, IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            Guard(title, slug, description, domainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void Edit(string title, string description, long categoryId, long subCategoryId,
            string secondarySubCategoryId, string slug, SeoData seoData, IProductDomainService domainService)
        {
            Guard(title, slug, description, domainService);
            Title = title;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void SerProductImage(string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));

            ImageName = imageName;
        }

        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            Images.Add(image);
        }

        public void RemoveImage(long id)
        {
            var images = Images.FirstOrDefault(x => x.Id == id);

            if (images is null)
                return;

            Images.Remove(images);
        }

        public void SetSpecification(List<ProductSpecification> specifications)
        {
            Specifications.ForEach(s => s.ProductId = Id);
            Specifications = specifications;
        }

        private void Guard(string title, string slug, string description, IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));

            if (slug != Slug)
                if (domainService.SlugIsExist(slug.ToSlug()))
                    throw new SlugIsDuplicatedException("اسلاگ تکراری است");
        }

    }
}
