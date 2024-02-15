using PharmaFinder.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Service
{
    public interface IUserTestimonialService
    {
        List<Usertestimonial> GetAllUsertestimonials();
        Usertestimonial GetUsertestimonialById(decimal id);
        void CreateUsertestimonial(Usertestimonial usertestimonialData);
        void UpdateUsertestimonial(Usertestimonial usertestimonialData);
        public void AcceptOrRejectTestimonial(Usertestimonial usertestimonialData);

        void DeleteUsertestimonial(decimal id);
    }
}

