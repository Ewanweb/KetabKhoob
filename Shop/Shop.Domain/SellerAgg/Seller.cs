using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus Status { get; private set; }
        public List<SellerInventory> Inventories { get; private set; }
        public DateTime LastUpdate { get; private set; }

        private Seller()
        {
            
        }

        public Seller(long userId, string shopName, string nationalCode, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);

            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories = new List<SellerInventory>();

            if (domainService.CheckSellerInformation(this) is false)
                throw new InvalidDomainDataException("اطلاعات فروشنده نامعتبر است");
        }

        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Edit(string shopName, string nationalCode, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);

            if (domainService.NationalCodeIsExist(nationalCode))
                throw new InvalidDomainDataException("کد ملی تکراری است");

            ShopName = shopName;
            NationalCode = nationalCode;
            LastUpdate = DateTime.Now;
        }

        public void AddInventory(SellerInventory inventory)
        {
            if (Inventories.Any(f => f.ProductId == inventory.ProductId))
                throw new NullOrEmptyDomainDataException("محصول یافت نشد");

            Inventories.Add(inventory);
        }

        public void EditInventory(SellerInventory inventory)
        {
            var inventories = Inventories.FirstOrDefault(f => f.ProductId == inventory.ProductId);

            if (inventories is null)
                return;
            
            Inventories.Remove(inventories);
            Inventories.Add(inventory);
        }

        public void DeleteInventory(long inventoryId)
        {
            var inventories = Inventories.FirstOrDefault(f => f.Id == inventoryId);

            if (inventories is null)
                throw new NullOrEmptyDomainDataException("محصول یافت نشد");

            Inventories.Remove(inventories);
        }

        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("کد ملی نامعتبر است");
        }
    }
}
