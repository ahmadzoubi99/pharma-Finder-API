using System;
using System.Collections.Generic;

namespace PharmaFinder.Core.Data
{
    public partial class Contactu
    {
        public decimal Contactusid { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
