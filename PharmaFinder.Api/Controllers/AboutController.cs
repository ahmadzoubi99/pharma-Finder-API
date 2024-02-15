using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
    
            private readonly IAboutService aboutService;

            public AboutController(IAboutService aboutService)
            {
                this.aboutService = aboutService;
            }

            [HttpGet]
            [Route("GetAllAbouts")]
            public IActionResult GetAllAbouts()
            {
                try
                {
                    var abouts = aboutService.GetAllAbouts();
                    return Ok(abouts);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred while retrieving abouts: " + ex.Message);
                }
            }

            [HttpGet]
            [Route("GetAboutById/{id}")]
            public IActionResult GetAboutById(int id)
            {
                try
                {
                    var about = aboutService.GetAboutById(id);
                    if (about == null)
                        return NotFound();

                    return Ok(about);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred while retrieving the about: " + ex.Message);
                }
            }

            [HttpPost]
            [Route("CreateAbout")]
            public IActionResult CreateAbout(About aboutData)
            {
                try
                {
                    aboutService.CreateAbout(aboutData);
                    return StatusCode(StatusCodes.Status201Created);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred while creating the about: " + ex.Message);
                }
            }

            [HttpPut]
            [Route("UpdateAbout")]
            public IActionResult UpdateAbout(About aboutData)
            {
                try
                {
                    aboutService.UpdateAbout(aboutData);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred while updating the about: " + ex.Message);
                }
            }

            [HttpDelete]
            [Route("DeleteAbout/{id}")]
            public IActionResult DeleteAbout(int id)
            {
                try
                {
                    aboutService.DeleteAbout(id);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "An error occurred while deleting the about: " + ex.Message);
                }
            }

        [HttpPost]
        [Route("UploadImage")]
        public About UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\m7mdv\\PharmaFinder-Angular-2\\src\\assets\\Images",fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            About item = new About();
            item.Image1 = fileName;
            return item;
        }
    }
    }

