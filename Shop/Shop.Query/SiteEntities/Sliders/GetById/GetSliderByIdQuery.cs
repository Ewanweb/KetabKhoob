using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Shop.Domain.RoleAgg;
using Shop.Query.SiteEntities.Dtos;

namespace Shop.Query.SiteEntities.Sliders.GetById
{
    public record GetSliderByIdQuery(long SliderId) : IQuery<SliderDto?>;
}
