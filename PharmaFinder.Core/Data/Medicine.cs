using System;
using System.Collections.Generic;

namespace PharmaFinder.Core.Data
{
    public partial class Medicine
    {
        public Medicine()
        {
            Ordermeds = new HashSet<Ordermed>();
            Phmeds = new HashSet<Phmed>();
        }

        public decimal Medicineid { get; set; }
        public string? Medicinename { get; set; }
        public decimal? Medicineprice { get; set; }
        public string? Medicinetype { get; set; }
        public string? Medicinedescription { get; set; }
        public string? Imagename { get; set; }

        public DateTime? Expiredate { get; set; }
        public string? Activesubstance { get; set; }

        public virtual ICollection<Ordermed> Ordermeds { get; set; }
        public virtual ICollection<Phmed> Phmeds { get; set; }
    }
}
