using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Service
{
    public interface IReadPrescriptionService
    {


        public List<string> ExtractWordsFromPDF(Stream file);
        public List<Medicine> FindMatchingMedicines(List<string> words);
        public List<string> ExtractMedsFromTxt(string med);
        public List<PharmaMedResult> GetMedicineDetails(decimal id);


    }
}
