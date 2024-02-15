using PharmaFinder.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Repository
{
    public interface IReadPrescriptionRepository
    {

        public List<PharmaMedResult> GetMedicineDetails(decimal id);

    }
}
