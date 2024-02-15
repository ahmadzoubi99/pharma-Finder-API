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
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public List<GetAllMedicineInPharmacy> GetAllMedicinesDetals()
        {
            return _medicineRepository.GetAllMedicinesDetals();
        }

        public List<Medicine> GetAllMedicines()
        {
            return _medicineRepository.GetAllMedicines();
        }

        public Medicine GetMedicineById(decimal id)
        {
            return _medicineRepository.GetMedicineById(id);
        }

        public void CreateMedicine(Medicine medicineData)
        {
            _medicineRepository.CreateMedicine(medicineData);
        }

        public void UpdateMedicine(Medicine medicineData)
        {
            _medicineRepository.UpdateMedicine(medicineData);
        }

        public void DeleteMedicine(decimal id)
        {
            _medicineRepository.DeleteMedicine(id);
        }
    }
}