using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult GenerateToken(User users)
        {
            var token = loginService.GenerateToken(users);

            if (token != null)
            {
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }


        }
    }
}
