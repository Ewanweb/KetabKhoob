using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.GetById;

public class GetSellerByIdQueryHandler(ShopContext context) : IQueryHandler<GetSellerByIdQuery, SellerDto?>
{
    private readonly ShopContext _context = context;
    public async Task<SellerDto?> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await _context.Sellers.FirstOrDefaultAsync(f => f.Id == request.SellerId, cancellationToken : cancellationToken );

        if (seller is null)
            return null;

        return new SellerDto()
        {
            Id = seller.Id,
            CreationDate = seller.CreationDate,
            ShopName = seller.ShopName,
            Status = seller.Status,
            NationalCode = seller.NationalCode,
            UserId = seller.UserId
        };
    }
}