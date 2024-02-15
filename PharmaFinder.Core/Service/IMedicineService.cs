using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Service
{
    public interface IMedicineService
    {
        public List<GetAllMedicineInPharmacy> GetAllMedicinesDetals();

        List<Medicine> GetAllMedicines();
        Medicine GetMedicineById(decimal id);
        void CreateMedicine(Medicine medicineData);
        void UpdateMedicine(Medicine medicineData);
        void DeleteMedicine(decimal id);
    }
}
