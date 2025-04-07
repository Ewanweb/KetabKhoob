using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Sliders;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Sliders;

internal class SliderRepository : BaseRepository<Slider>, ISliderRepository
{
    private readonly ShopContext _context;
    public SliderRepository(ShopContext context) : base(context)
    {
        _context = context;
    }

    public void Delete(Slider slider)
    {
        _context.Sliders.Remove(slider);
    }
}