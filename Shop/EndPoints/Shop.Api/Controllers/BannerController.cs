using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Presentation.Facade.Sellers;
using Shop.Presentation.Facade.SiteEntities.Banner;
using Shop.Query.Sellers.DTOs;
using Shop.Query.SiteEntities.Dtos;

namespace Shop.Api.Controllers
{
    public class BannerController : ApiController
    {
        private readonly IBannerFacade _bannerFacade;

        public BannerController(IBannerFacade bannerFacade)
        {
            _bannerFacade = bannerFacade;
        }

        [HttpGet]
        public async Task<ApiResult<List<BannerDto>>> GetBannerByList()
        {
            var result = await _bannerFacade.GetBanners();

            return QueryResult(result);
        }

        [HttpGet("{bannerId}")]
        public async Task<ApiResult<BannerDto?>> GetBannerById(long bannerId)
        {
            var result = await _bannerFacade.GetBannerById(bannerId);

            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> Create(CreateBannerCommand command)
        {
            var result = await _bannerFacade.CreateBanner(command);

            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> Edit(EditBannerCommand command)
        {
            var result = await _bannerFacade.EditBanner(command);

            return CommandResult(result);
        }

    }
}
