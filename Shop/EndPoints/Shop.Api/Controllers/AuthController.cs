using Common.Application;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JWTUtil;
using Shop.Api.ViewModels.Auth;
using Shop.Application.Users.Register;
using Shop.Domain.UserAgg;
using Shop.Presentation.Facade.Users;

namespace Shop.Api.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUserFacade _userFacade;
        private readonly IConfiguration _configuration;
        public AuthController(IUserFacade userFacade, IConfiguration configuration)
        {
            _userFacade = userFacade;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<ApiResult<string?>> Login(LoginViewModel viewModel)
        {
            var user = await _userFacade.GetUserByPhoneNumber(viewModel.PhoneNumber);

            if (user is null)
                return CommandResult(OperationResult<string>.Error("کاربری با این مشخصات یافت نشد")!);

            if (!Sha256Hasher.IsCompare(user.Password, viewModel.Password))
                return CommandResult(OperationResult<string>.Error("کاربری با این مشخصات یافت نشد")!);

            if (user.IsActive is false)
                return CommandResult(OperationResult<string>.Error("حساب کاربری شما غیر فعال است")!);

            var token = JwtTokenBuilder.BuildToken(user, _configuration);

            return new ApiResult<string?>()
            {
                Data = token,
                IsSuccess = true,
                MetaData = new(),
            };
        }

        [HttpPost("Register")]
        public async Task<ApiResult> Register(RegisterViewModel viewModel)
        {
            var command = new RegisterUserCommand(viewModel.PhoneNumber, viewModel.Password);
            var result = await _userFacade.RegisterUser(command);

            return CommandResult(result);
        }
    }
}
