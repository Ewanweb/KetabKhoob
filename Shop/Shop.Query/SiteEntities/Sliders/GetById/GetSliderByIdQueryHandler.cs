using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.Dtos;

namespace Shop.Query.SiteEntities.Sliders.GetById;

public class GetSliderByIdQueryHandler(ShopContext context) : IQueryHandler<GetSliderByIdQuery, SliderDto?>
{
    private readonly ShopContext _context = context;
    public async Task<SliderDto?> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
    {
        var slider = await _context.Sliders.FirstOrDefaultAsync(f => f.Id == request.SliderId, cancellationToken : cancellationToken );

        if (slider is null)
            return null;

        return new SliderDto()
        {
            Id = slider.Id,
            CreationDate = slider.CreationDate,
            Link = slider.Link,
            ImageName = slider.ImageName,
            Title = slider.Title
        };
    }
}