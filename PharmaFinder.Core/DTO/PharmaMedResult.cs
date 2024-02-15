using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.DTO
{
    public class PharmaMedResult
    {
        public string? Pharmacyname { get; set; }
        public string? Medicinename { get; set; }
        public string? Imagename { get; set; }
        public decimal? Lng { get; set; }
        public decimal? Lat { get; set; }

        public string? Medicinedescription { get; set; }
        public decimal? Medicineprice { get; set; }
        public decimal? Medicineid { get; set; }
        public decimal? Pharmacyid { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Distacne { get; set; }



    }
}
