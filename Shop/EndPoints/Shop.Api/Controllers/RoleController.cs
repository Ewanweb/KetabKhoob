using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Presentation.Facade.Comments;
using Shop.Presentation.Facade.Roles;
using Shop.Query.Roles;

namespace Shop.Api.Controllers
{
    public class RoleController : ApiController
    {
        private readonly IRoleFacade _roleFacade;

        public RoleController(IRoleFacade roleFacade)
        {
            _roleFacade = roleFacade;
        }

        [HttpGet]
        public async Task<ApiResult<List<RoleDto>>> GetRoleList()
        {
            var result = await _roleFacade.GetRoles();
            return QueryResult(result);
        }

        [HttpGet("{roleId}")]
        public async Task<ApiResult<RoleDto?>> GetRoleById(long roleId)
        {
            var result = await _roleFacade.GetRoleById(roleId);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> Create(CreateRoleCommand command)
        {
            var result = await _roleFacade.CreateRole(command);

            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> Edit(EditRoleCommand command)
        {
            var result = await _roleFacade.EditRole(command);

            return CommandResult(result);
        }

    }
}
