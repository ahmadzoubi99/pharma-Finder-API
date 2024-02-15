using PharmaFinder.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Repository
{
    public interface IContactUsRepository
    {
        List<Contactu> GetAllContactus();
        Contactu GetContactusById(decimal id);
        void CreateContactus(Contactu contactusData);
        void DeleteContactus(decimal id);
    }
}
