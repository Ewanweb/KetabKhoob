using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities.Banner;

namespace Shop.Application.SiteEntities.Banners.Create
{
    public record CreateBannerCommand(string Link, IFormFile ImageFile, BannerPosition Position) : IBaseCommand;
}
