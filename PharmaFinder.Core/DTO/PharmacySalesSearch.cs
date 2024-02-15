using PharmaFinder.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.DTO
{
    public class PharmacySalesSearch
    {
        public decimal? Orderprice { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? Orderdate { get; set; }
        public string? Pharmacyname { get; set; }
        public string? Medicinename { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

    }
}
