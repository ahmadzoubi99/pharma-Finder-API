﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.DTO
{
    public class AllSalesByYearReport
    {
        public int Year { get; set; }
        public decimal? Orderprice { get; set; }
        public DateTime? Orderdate { get; set; }
        public string? Pharmacyname { get; set; }
        public decimal? Quantity { get; set; }
    }
}
