using PharmaFinder.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.DTO
{
    public class InvoiceDTO
    {
        public decimal Orderid { get; set; }
        public DateTime? Orderdate { get; set; }
        public decimal? Orderprice { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }


    }
}
