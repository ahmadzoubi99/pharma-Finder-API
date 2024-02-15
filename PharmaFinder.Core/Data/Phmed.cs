using System;
using System.Collections.Generic;

namespace PharmaFinder.Core.Data
{
    public partial class Phmed
    {
        public decimal Phmedid { get; set; }
        public decimal? Pharmacyid { get; set; }
        public decimal? Medicineid { get; set; }
        public decimal? Quantity { get; set; }

        public virtual Medicine? Medicine { get; set; }
        public virtual Pharmacy? Pharmacy { get; set; }
    }
}
