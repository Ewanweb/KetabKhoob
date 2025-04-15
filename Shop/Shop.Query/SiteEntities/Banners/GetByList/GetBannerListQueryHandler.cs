using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SiteEntities.Banners;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.Dtos;

namespace Shop.Query.SiteEntities.Banners.GetByList;

public class GetBannerListQueryHandler(ShopContext context) : IQueryHandler<GetBannerListQuery, List<BannerDto>>
{
    private readonly ShopContext _context = context;
    public async Task<List<BannerDto>> Handle(GetBannerListQuery request, CancellationToken cancellationToken)
    {
        var banner = await _context.Banners.Select(b => new BannerDto()
        {
            Id = b.Id,
            CreationDate = b.CreationDate,
            Link = b.Link,
            ImageName = b.ImageName,
            Position = b.Position
        }).ToListAsync(cancellationToken : cancellationToken);


        return banner;
    }
}