using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("SendEmail")]

        public void SendEmail(SendEmailDto emailDto)
        {
            _emailService.SendEmail(emailDto);
        }

        [HttpPost]
        [Route("SendInvoice")]

        public void SendInvoice([FromBody] SendInvoicePayload payload)
        {
            _emailService.SendInvoice(payload.EmailDto, payload.Items, payload.InvoiceDTO);
        }

    }
}
