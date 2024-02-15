using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Service;
using PharmaFinder.Infra.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadPrescriptionController : ControllerBase
    {
        private readonly IReadPrescriptionService _prescriptionReadService;

        public ReadPrescriptionController(IReadPrescriptionService readPrescriptionService)
        {
            _prescriptionReadService = readPrescriptionService;
        }

        [HttpPost]
        [Route("ReadPrescription")]

        public IActionResult ReadPrescription()
        {
            var file = Request.Form.Files[0];
            
            try
            {
                if (file == null || file.Length <= 0)
                    return BadRequest("Invalid file or empty content.");

                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;

                    List<String> extractedPdf = _prescriptionReadService.ExtractWordsFromPDF(stream);
                    List<Medicine> medicines = _prescriptionReadService.FindMatchingMedicines(extractedPdf);
                    List<PharmaMedResult> medicinesDetails = new List<PharmaMedResult>();
                    foreach (var item in medicines)
                    {
                        medicinesDetails.AddRange(_prescriptionReadService.GetMedicineDetails(item.Medicineid));
                    }
                    return Ok(medicinesDetails);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ReadTxtPrescription/{medTxt}")]
        public IActionResult ReadTxtPrescription (string medTxt)
        {

            try
            {
                if (medTxt == null)
                    return BadRequest("empty content.");


                List<String> extractedTxt = _prescriptionReadService.ExtractMedsFromTxt(medTxt);
                    List<Medicine> medicines = _prescriptionReadService.FindMatchingMedicines(extractedTxt);
                    List<PharmaMedResult> medicinesDetails = new List<PharmaMedResult>();
                    foreach (var item in medicines)
                    {
                        medicinesDetails.AddRange(_prescriptionReadService.GetMedicineDetails(item.Medicineid));
                    }
                    return Ok(medicinesDetails);
                }
            
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}

