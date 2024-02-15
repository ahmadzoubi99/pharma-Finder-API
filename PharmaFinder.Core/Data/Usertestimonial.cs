using System;
using System.Collections.Generic;

namespace PharmaFinder.Core.Data
{
    public partial class Usertestimonial
    {
        public decimal Utestimonialid { get; set; }
        public decimal? Userid { get; set; }
        public string? Testimonialtext { get; set; }
        public string? Status { get; set; }
        public DateTime? Testimonialdate { get; set; }

        public virtual User? User { get; set; }
    }
}
