using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SiteEntities.Banners;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.Dtos;

namespace Shop.Query.SiteEntities.Sliders.GetByList;

public class GetSliderListQueryHandler(ShopContext context) : IQueryHandler<GetSliderListQuery, List<SliderDto>>
{
    private readonly ShopContext _context = context;
    public async Task<List<SliderDto>> Handle(GetSliderListQuery request, CancellationToken cancellationToken)
    {
        var slider = await _context.Sliders.Select(b => new SliderDto()
        {
            Id = b.Id,
            CreationDate = b.CreationDate,
            Link = b.Link,
            ImageName = b.ImageName,
            Title = b.Title
        }).ToListAsync(cancellationToken: cancellationToken);


        return slider;
    }
}