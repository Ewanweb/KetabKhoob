namespace Shop.Domain.ProductAgg.ProductDomainService;

public interface IProductDomainService
{
    bool SlugIsExist(string slug);
}