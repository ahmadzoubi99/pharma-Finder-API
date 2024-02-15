using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        [Route("GetAllMedicines")]
        public List<Medicine> GetAllMedicines()
        {
            return _medicineService.GetAllMedicines();
        }
        [HttpGet]
        [Route("GetAllMedicinesDetals")]
        public List<GetAllMedicineInPharmacy> GetAllMedicinesDetals()
        {
            return _medicineService.GetAllMedicinesDetals();
        }

        [HttpGet]
        [Route("GetMedicineById/{id}")]
        public Medicine GetMedicineById(decimal id)
        {
            return _medicineService.GetMedicineById(id);
        }

        [HttpPost]
        [Route("CreateMedicine")]
        public IActionResult CreateMedicine(Medicine medicine)
        {
            _medicineService.CreateMedicine(medicine);
            return StatusCode(201);
        }

        [HttpPut]
        [Route("UpdateMedicine")]
        public IActionResult UpdateMedicine(Medicine medicine)
        {
            _medicineService.UpdateMedicine(medicine);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteMedicine/{id}")]
        public IActionResult DeleteMedicine(decimal id)
        {
            _medicineService.DeleteMedicine(id);
            return Ok();
        }



        [Route("uploadImage")]
        [HttpPost]
        public Medicine UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\Ahmad\\PharmaFinder-Angular-2\\src\\assets\\Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Medicine item = new Medicine();
            item.Imagename = fileName;
            return item;
        }
        //[Route("uploadImages")]
        //[HttpPost]
        //public User UploadIMages()
        //{
        //    var file = Request.Form.Files[0];
        //    var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        //    var fullPath = Path.Combine("C:\\Users\\Ahmad\\PharmaFinder-Angular-1\\src\\assets\\Images", fileName);
        //    using (var stream = new FileStream(fullPath, FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //    }
        //    User item = new User();
        //    item.Profileimage = fileName;
        //    return item;
        //}

        [Route("uploadImages")]
        [HttpPost]
        public User UploadImages()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\Ahmad\\PharmaFinder-Angular-1\\src\\assets\\Images", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            User item = new User();
            item.Profileimage = fileName;
            return item;
        }


    }
}