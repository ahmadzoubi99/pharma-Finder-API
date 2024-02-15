using System;
using System.Collections.Generic;

namespace PharmaFinder.Core.Data
{
    public partial class Pharmacy
    {
        public Pharmacy()
        {
            Orders = new HashSet<Order>();
            Phmeds = new HashSet<Phmed>();
        }

        public decimal Pharmacyid { get; set; }
        public string? Pharmacyname { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        public decimal? Lng { get; set; }
        public decimal? Lat { get; set; }
        public string? Email { get; set; }
        public string? Phonenumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Phmed> Phmeds { get; set; }
    }
}
