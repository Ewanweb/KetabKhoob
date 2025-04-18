﻿using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers;

public class SellerDomainService : ISellerDomainService
{
    private readonly ISellerRepository _repository;

    public SellerDomainService(ISellerRepository repository)
    {
        _repository = repository;
    }

    public bool IsValidSellerInformation(Seller seller)
    {
        var exist = _repository.Exists(r => r.NationalCode == seller.NationalCode || r.UserId == seller.UserId);
        return !exist;
    }

    public bool NationalCodeIsExist(string nationalCode)
    {
        return  _repository.Exists(r => r.NationalCode == nationalCode );
    }
}