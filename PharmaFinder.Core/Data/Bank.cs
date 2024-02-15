using System;
using System.Collections.Generic;

namespace PharmaFinder.Core.Data
{
    public partial class Bank
    {
        public decimal Bankid { get; set; }
        public string? Cardholder { get; set; }
        public decimal? Cardnumber { get; set; }
        public decimal? Cvv { get; set; }
        public DateTime? Expiredate { get; set; }
        public decimal? Balance { get; set; }
    }
}
