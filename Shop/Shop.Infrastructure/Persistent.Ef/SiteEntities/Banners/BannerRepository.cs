using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.Banners;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Banners
{
    internal class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        private readonly ShopContext _context;
        public BannerRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public void Delete(Banner banner)
        {
            _context.Banners.Remove(banner);
        }
    }
}