using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
 
        
            private readonly IContactUsService _contactUsService;

            public ContactUsController(IContactUsService contactUsService)
            {
                _contactUsService = contactUsService;
            }

            [HttpGet]
            [Route("GetAllContactUs")]
            public List<Contactu> GetAllContactUs()
            {
                return _contactUsService.GetAllContactus();
            }

            [HttpGet]
            [Route("GetContactUsById/{id}")]
            public Contactu GetContactUsById(decimal id)
            {
                return _contactUsService.GetContactusById(id);
            }

            [HttpPost]
            [Route("CreateContactUs")]
            public IActionResult CreateContactUs(Contactu contactUs)
            {
                _contactUsService.CreateContactus(contactUs);
                return StatusCode(201);
            }



            [HttpDelete]
            [Route("DeleteContactUs/{id}")]
            public IActionResult DeleteContactUs(decimal id)
            {
                _contactUsService.DeleteContactus(id);
                return Ok();
            }
        }
    }

