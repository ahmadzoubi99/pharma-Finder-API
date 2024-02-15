using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Repository
{
    public interface IMedicineRepository
    {
        public List<GetAllMedicineInPharmacy> GetAllMedicinesDetals();
        public List<Medicine> GetAllMedicines();

        Medicine GetMedicineById(decimal id);
        void CreateMedicine(Medicine medicineData);
        void UpdateMedicine(Medicine medicineData);
        void DeleteMedicine(decimal id);
    }
}