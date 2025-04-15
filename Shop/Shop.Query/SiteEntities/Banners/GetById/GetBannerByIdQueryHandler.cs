using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.Dtos;

namespace Shop.Query.SiteEntities.Banners.GetById;

public class GetBannerByIdQueryHandler(ShopContext context) : IQueryHandler<GetBannerByIdQuery, BannerDto?>
{
    private readonly ShopContext _context = context;
    public async Task<BannerDto?> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
    {
        var banner = await _context.Banners.FirstOrDefaultAsync(f => f.Id == request.BannerId, cancellationToken : cancellationToken );

        if (banner is null)
            return null;

        return new BannerDto()
        {
            Id = banner.Id,
            CreationDate = banner.CreationDate,
            Link = banner.Link,
            ImageName = banner.ImageName,
            Position = banner.Position
        };
    }
}