namespace Shop.Domain.SellerAgg.Services;

public interface ISellerDomainService
{
    bool CheckSellerInformation(Seller seller);
    bool NationalCodeIsExist(string nationalCode);
}