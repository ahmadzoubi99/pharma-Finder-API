using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserTestimonialController : ControllerBase
    {
        private readonly IUserTestimonialService _usertestimonialService;

        public UserTestimonialController(IUserTestimonialService usertestimonialService)
        {
            _usertestimonialService = usertestimonialService;
        }

        [HttpGet]
        [Route("GetAllUsertestimonials")]
        public List<Usertestimonial> GetAllUsertestimonials()
        {
            return _usertestimonialService.GetAllUsertestimonials();
        }

        [HttpGet]
        [Route("GetUsertestimonialById/{id}")]
        public Usertestimonial GetUsertestimonialById(decimal id)
        {
            return _usertestimonialService.GetUsertestimonialById(id);
        }

        [HttpPost]
        [Route("CreateUsertestimonial")]
        public IActionResult CreateUsertestimonial(Usertestimonial usertestimonial)
        {
            _usertestimonialService.CreateUsertestimonial(usertestimonial);
            return StatusCode(201);
        }

        [HttpPut]
        [Route("UpdateUsertestimonial")]
        public IActionResult UpdateUsertestimonial( Usertestimonial usertestimonial)
        {
            _usertestimonialService.UpdateUsertestimonial(usertestimonial);
            return Ok();
        }

        [HttpPut]
        [Route("AcceptOrRejectTestimonial")]
        public IActionResult AcceptOrRejectTestimonial( Usertestimonial usertestimonial)
        {
            _usertestimonialService.UpdateUsertestimonial(usertestimonial);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUsertestimonial/{id}")]
        public IActionResult DeleteUsertestimonial(decimal id)
        {
            _usertestimonialService.DeleteUsertestimonial(id);
            return Ok();
        }
    }
}
