using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhMedController : ControllerBase
    {
        readonly IPhMedServices _services;
        public PhMedController(IPhMedServices medServices)
        {
            this._services = medServices;
        }

        [HttpPost]
        [Route("createPhMed")]
        public void CreatephMed(Phmed phmed)
        {
            _services.CreatephMed(phmed);
        }
    }
}
