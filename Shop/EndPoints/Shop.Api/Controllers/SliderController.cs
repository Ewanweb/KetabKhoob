using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Sellers.Edit;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Presentation.Facade.SiteEntities.Slider;
using Shop.Query.SiteEntities.Dtos;

namespace Shop.Api.Controllers
{
    public class SliderController : ApiController
    {
        private readonly ISliderFacade _sliderFacade;

        public SliderController(ISliderFacade sliderFacade)
        {
            _sliderFacade = sliderFacade;
        }

        [HttpGet]
        public async Task<ApiResult<List<SliderDto>>> GetSliderByList()
        {
            var result = await _sliderFacade.GetSliders();

            return QueryResult(result);
        }

        [HttpGet("{sliderId}")]
        public async Task<ApiResult<SliderDto?>> GetBannerById(long sliderId)
        {
            var result = await _sliderFacade.GetSliderById(sliderId);

            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> Create(CreateSliderCommand command)
        {
            var result = await _sliderFacade.CreateSlider(command);

            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> Edit(EditSliderCommand command)
        {
            var result = await _sliderFacade.EditSlider(command);

            return CommandResult(result);
        }
    }
}
