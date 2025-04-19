using AutoMapper;
using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Users;
using Shop.Application.Users.AddAddress;
using Shop.Application.Users.DeleteUserAddress;
using Shop.Application.Users.EditUserAddress;
using Shop.Presentation.Facade.Users.Addresses;
using Shop.Query.Users.DTOs;

namespace Shop.Api.Controllers
{
    public class UserAddressController : ApiController
    {
        private readonly IUserAddressFacade _userAddressFacade;
        private readonly IMapper _mapper;

        public UserAddressController(IUserAddressFacade userAddressFacade, IMapper mapper)
        {
            _userAddressFacade = userAddressFacade;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<ApiResult<List<AddressDto>>> GetUserAddressByList(long userId)
        {
            var result = await _userAddressFacade.GetList(userId);
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<AddressDto?>> GetUserAddressById(long id)
        {
            var result = await _userAddressFacade.GetById(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> AddUserAddress(AddUserAddressViewModel viewModel)
        {
            var command = _mapper.Map<AddUserAddressCommand>(viewModel);
            command.UserId = User.GetUserId();
            var result = await _userAddressFacade.AddAddress(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditUserAddress(EditUserAddressViewModel viewModel)
        {
            var command = _mapper.Map<EditUserAddressCommand>(viewModel);
            command.UserId = User.GetUserId();
            var result = await _userAddressFacade.EditAddress(command);
            return CommandResult(result);
        }

        [HttpDelete("{addressId}")]
        public async Task<ApiResult> RemoveUserAddress(long addressId)
        {
            var command = new DeleteUserAddressCommand(1, addressId);
            var result = await _userAddressFacade.DeleteAddress(command);
            return CommandResult(result);
        }


    }
}
