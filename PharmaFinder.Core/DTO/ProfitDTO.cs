using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.DTO
{
    public class ProfitDTO

    {
        public string? month { get; set; }
        public decimal? year { get; set; }

        public decimal? value { get; set; }

    }
}
