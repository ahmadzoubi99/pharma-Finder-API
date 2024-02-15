using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet]
        public ActionResult<List<Bank>> GetAllBanks()
        {
            return _bankService.GetAllBanks();
        }

        [HttpGet("{id}")]
        public ActionResult<Bank> GetBankById(decimal id)
        {
            return _bankService.GetBankById(id);
        }

        [HttpPost]
        public IActionResult CreateBank(Bank bank)
        {
            _bankService.CreateBank(bank);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBank(decimal id, Bank bank)
        {
            if (id != bank.Bankid)
            {
                return BadRequest();
            }

            _bankService.UpdateBank(bank);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBank(decimal id)
        {
            _bankService.DeleteBank(id);
            return Ok();
        }
    }
}
