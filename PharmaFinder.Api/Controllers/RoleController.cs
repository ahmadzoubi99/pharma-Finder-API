using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public List<Role> GetAllRoles()
        {
            return _roleService.GetAllRoles();
        }

        [HttpGet]
        [Route("GetRoleById/{id}")]
        public Role GetRoleById(decimal id)
        {
            return _roleService.GetRoleById(id);
        }

        [HttpPost]
        [Route("CreateRole")]
        public IActionResult CreateRole(Role role)
        {
            _roleService.CreateRole(role);
            return StatusCode(201);
        }

        [HttpPut]
        [Route("UpdateRole")]
        public IActionResult UpdateRole( Role role)
        {
            _roleService.UpdateRole(role);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteRole/{id}")]
        public IActionResult DeleteRole(decimal id)
        {
            _roleService.DeleteRole(id);
            return Ok();
        }
    }
}
