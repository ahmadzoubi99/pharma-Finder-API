using System;
using System.Collections.Generic;

namespace PharmaFinder.Core.Data
{
    public partial class Ordermed
    {
        public decimal Ordermedid { get; set; }
        public decimal? Medicineid { get; set; }
        public decimal? Orderid { get; set; }
        public decimal? Quantity { get; set; }
        public decimal Pharmacyid { get; set; }

        public virtual Medicine? Medicine { get; set; }
        public virtual Order? Order { get; set; }
    }
}
