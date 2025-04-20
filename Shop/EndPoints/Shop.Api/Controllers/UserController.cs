using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Users.ChargeUserWallet;
using Shop.Application.Users.Create;
using Shop.Application.Users.Edit;
using Shop.Application.Users.Register;
using Shop.Presentation.Facade.Categories;
using Shop.Presentation.Facade.Users;
using Shop.Query.Categories.DTOs;
using Shop.Query.Users.DTOs;

namespace Shop.Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpGet]
        public async Task<ApiResult<UserFilterResult>> GetUsersByFilter([FromQuery] UserFilterParams filterParams)
        {
            var result = await _userFacade.GetUserByFilter(filterParams);

            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<UserDto?>> GetUserById(long id)
        {
            var result = await _userFacade.GetUserById(id);

            return QueryResult(result);
        }

        [HttpGet("{phoneNumber}")]
        public async Task<ApiResult<UserDto?>> GetUserById(string phoneNumber)
        {
            var result = await _userFacade.GetUserByPhoneNumber(phoneNumber);

            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> Create(CreateUserCommand command)
        {
            var result = await _userFacade.CreateUser(command);

            return CommandResult(result);
        }

        //[HttpPost("CharegeUserWallet")]
        //public async Task<ApiResult> Create(ChargeUserWalletCommand command)
        //{
        //    var result = await _userFacade.U(command);

        //    return CommandResult(result);
        //}


        [HttpPut]
        public async Task<ApiResult> Edit(EditUserCommand command)
        {
            var result = await _userFacade.EditUser(command);

            return CommandResult(result);
        }
    }
}
