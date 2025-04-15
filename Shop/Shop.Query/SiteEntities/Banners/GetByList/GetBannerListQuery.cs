using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Query.SiteEntities.Dtos;

namespace Shop.Query.SiteEntities.Banners.GetByList
{
    public record GetBannerListQuery() : IQuery<List<BannerDto>>;
}
