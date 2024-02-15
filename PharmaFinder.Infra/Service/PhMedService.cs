using PharmaFinder.Core.Data;
using PharmaFinder.Core.Repository;
using PharmaFinder.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Service
{
    public class PhMedService: IPhMedServices
    {
        private readonly IPhMedRepsitory phMedRepsitory;

        public PhMedService(IPhMedRepsitory phMedRepsitory)
        {
               this.phMedRepsitory = phMedRepsitory;
        }
        public void CreatephMed(Phmed phmed)
        {
            phMedRepsitory.CreatephMed(phmed); 
        }

    }
}
