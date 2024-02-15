using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet]
        [Route("GetAllHomes")]
        public IActionResult GetAllHomes()
        {
            try
            {
                var homes = homeService.GetAllHomes();
                return Ok(homes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving homes: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetHomeById/{id}")]
        public IActionResult GetHomeById(int id)
        {
            try
            {
                var home = homeService.GetHomeById(id);
                if (home == null)
                    return NotFound();

                return Ok(home);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the home: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateHome")]
        public IActionResult CreateHome(Home homeData)
        {
            try
            {
                homeService.CreateHome(homeData);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the home: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateHome")]
        public IActionResult UpdateHome(Home homeData)
        {
            try
            {
                homeService.UpdateHome(homeData);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the home: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteHome/{id}")]
        public IActionResult DeleteHome(int id)
        {
            try
            {
                homeService.DeleteHome(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the home: " + ex.Message);
            }
        }
        [HttpPost]
        [Route("UploadImage")]
        public Home UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\m7mdv\\PharmaFinder-Angular-2\\src\\assets\\Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Home item = new Home();
            item.Image1 = fileName;
            return item;
        }
    }
}
