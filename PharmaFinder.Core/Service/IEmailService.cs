using PharmaFinder.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Service
{
    public interface IEmailService
    {
        public void SendEmail(SendEmailDto emailDto);

        public void SendInvoice(SendEmailDto emailDto, List<PharmaMedResult> items, InvoiceDTO invoiceDTO);

    }
}
