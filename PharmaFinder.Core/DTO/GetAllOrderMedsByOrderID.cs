﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.DTO
{
    public class GetAllOrderMedsByOrderID
    {
        public string? Medicinename { get; set; }
        public decimal? Medicineprice { get; set; }
        public string? Medicinetype { get; set; }
        public string? Medicinedescription { get; set; }
        public DateTime? Expiredate { get; set; }
        public string? Activesubstance { get; set; }
        public decimal? Quantity { get; set; }
    }
}
