using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.DTO
{
    public class GetALLInformationOrders
    {
        public string? Username { get; set; }
        public decimal Orderid { get; set; }
        public DateTime? Orderdate { get; set; }
        public string? Approval { get; set; }
        public decimal? Orderprice { get; set; }
        public string? Status { get; set; }


    }
}
