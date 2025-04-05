using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities.Banner;

namespace Shop.Application.SiteEntities.Banners.Create;

public record EditBannerCommand(long Id, string Link, IFormFile? ImageFile, BannerPosition Position) : IBaseCommand;