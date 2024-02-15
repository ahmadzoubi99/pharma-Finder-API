using PharmaFinder.Core.Data;
using PharmaFinder.Core.Repository;
using PharmaFinder.Core.Service;
using PharmaFinder.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Service
{
    public class UserTestimonialService:IUserTestimonialService
    {
        private readonly IUserTestmonialRepository _usertestimonialRepository;

        public UserTestimonialService(IUserTestmonialRepository usertestimonialRepository)
        {
            _usertestimonialRepository = usertestimonialRepository;
        }

        public List<Usertestimonial> GetAllUsertestimonials()
        {
            return _usertestimonialRepository.GetAllUsertestimonials();
        }

        public Usertestimonial GetUsertestimonialById(decimal id)
        {
            return _usertestimonialRepository.GetUsertestimonialById(id);
        }

        public void CreateUsertestimonial(Usertestimonial usertestimonialData)
        {
            _usertestimonialRepository.CreateUsertestimonial(usertestimonialData);
        }

        public void UpdateUsertestimonial(Usertestimonial usertestimonialData)
        {
            _usertestimonialRepository.UpdateUsertestimonial(usertestimonialData);
        }

        public void DeleteUsertestimonial(decimal id)
        {
            _usertestimonialRepository.DeleteUsertestimonial(id);
        }
        public void AcceptOrRejectTestimonial(Usertestimonial usertestimonial)
        {
            _usertestimonialRepository.AcceptOrRejectTestimonial(usertestimonial);
        }

    }
}
