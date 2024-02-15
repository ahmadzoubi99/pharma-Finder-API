using PharmaFinder.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Data
{
    public class SendInvoicePayload
    {
        public SendEmailDto EmailDto { get; set; }
        public List<PharmaMedResult> Items { get; set; }
        public InvoiceDTO InvoiceDTO { get; set; }
    }
}
