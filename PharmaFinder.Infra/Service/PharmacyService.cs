using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Repository;
using PharmaFinder.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Service
{
    public class PharmacyService:IPharmacyService
    {
        private readonly IPharmacyRepository _pharmacyRepository;

        public int GetPharmacyCount()
        {
            return _pharmacyRepository.GetPharmacyCount();
        }
        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        public List<Pharmacy> GetAllPharmacies()
        {
            return _pharmacyRepository.GetAllPharmacies();
        }

        public Pharmacy GetPharmacyById(decimal id)
        {
            return _pharmacyRepository.GetPharmacyById(id);
        }

        public void CreatePharmacy(Pharmacy pharmacyData)
        {
            _pharmacyRepository.CreatePharmacy(pharmacyData);
        }

        public void UpdatePharmacy(Pharmacy pharmacyData)
        {
            _pharmacyRepository.UpdatePharmacy(pharmacyData);
        }

        public void DeletePharmacy(decimal id)
        {
            _pharmacyRepository.DeletePharmacy(id);
        }

        public List<PharmacyNameSearch> SearchPharmacyName(PharmacyNameSearch search)
        {
            return _pharmacyRepository.SearchPharmacyName(search);
        }

        public List<GetAllMedicineInPharmacy> GetAllMedcineInPharmmacy(decimal id)
        {
            return _pharmacyRepository.GetAllMedcineInPharmmacy(id);
        }
        public List<Order> GetAllOrdersInPharmmacy(decimal id)
        {
            return _pharmacyRepository.GetAllOrdersInPharmmacy(id);

        }
        public int GetMedicineCountInPharmacy(decimal id)
        {
            return _pharmacyRepository.GetMedicineCountInPharmacy(id);
        }
        public int SalesPharmacy(decimal id)
        {
            return _pharmacyRepository.SalesPharmacy(id);
        }
        public List<GetAllOrderMedsByOrderIdInPharmacy> GetAllOrderMedsByOrderIdInPharmacy(GetAllOrderMedsByOrderIdInPharmacy obj)
        {
            return _pharmacyRepository.GetAllOrderMedsByOrderIdInPharmacy(obj);
        }
        public List<SalesSearchInPharmacy> SalesSearch(SalesSearch2 search)
        {
            return _pharmacyRepository.SalesSearch(search);
        }
        public void CreateMedcineInPharmacy(CreateMedcineInpharmacy createMedcineInpharmacy)
        {
             _pharmacyRepository.CreateMedcineInPharmacy(createMedcineInpharmacy);
        }

        public void updateMedcineInPharmacy(CreateMedcineInpharmacy updateMedcineInpharmacy)
        {
            _pharmacyRepository.updateMedcineInPharmacy(updateMedcineInpharmacy);
        }


    }
}
