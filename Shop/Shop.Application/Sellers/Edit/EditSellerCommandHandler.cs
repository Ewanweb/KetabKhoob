﻿using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Application.Sellers.Edit;

public class EditSellerCommandHandler : IBaseCommandHandler<EditSellerCommand>
{
    private readonly ISellerRepository _sellerRepository;
    private readonly ISellerDomainService _sellerDomainService;

    public EditSellerCommandHandler(ISellerRepository sellerRepository, ISellerDomainService domainService)
    {
        _sellerRepository = sellerRepository;
        _sellerDomainService = domainService;
    }
    public async Task<OperationResult> Handle(EditSellerCommand request, CancellationToken cancellationToken)
    {
        var seller = await _sellerRepository.GetTracking(request.Id);

        if (seller is null)
            return OperationResult.NotFound();

        seller.Edit(request.ShopName, request.NationalCode, _sellerDomainService);

        await _sellerRepository.Save();

        return OperationResult.Success();
    }
}