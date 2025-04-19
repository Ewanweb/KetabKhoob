using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.Create;
using Shop.Application.Sellers.Edit;
using Shop.Presentation.Facade.Roles;
using Shop.Presentation.Facade.Sellers;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.GetById;

namespace Shop.Api.Controllers
{
    public class SellerController : ApiController
    {
        private readonly ISellerFacade _sellerFacade;

        public SellerController(ISellerFacade sellerFacade)
        {
            _sellerFacade = sellerFacade;
        }

        [HttpGet]
        public async Task<ApiResult<SellerFilterResult>> GetSellersByFilter([FromQuery] SellerFilterParams filterParams)
        {
            var result = await _sellerFacade.GetSellersByFilter(filterParams);

            return QueryResult(result);
        }

        [HttpGet("{sellerId}")]
        public async Task<ApiResult<SellerDto?>> GetSellersById(long sellerId)
        {
            var result = await _sellerFacade.GetSellerById(sellerId);

            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> Create(CreateSellerCommand command)
        {
            var result = await _sellerFacade.CreateSeller(command);

            return CommandResult(result);
        }


        [HttpPut]
        public async Task<ApiResult> Edit(EditSellerCommand command)
        {
            var result = await _sellerFacade.EditSeller(command);

            return CommandResult(result);
        }


    }
}
