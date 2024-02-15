﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.DTO
{
    public class SalesSearch2
    {
        public string? Username { get; set; }
        public decimal Orderid { get; set; }
        public string? Pharmacyname { get; set; }

        public DateTime? Orderdate { get; set; }
        public decimal? Orderprice { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? idphar { get; set; }




    }
}
