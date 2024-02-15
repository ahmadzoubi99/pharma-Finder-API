using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Core.Repository
{
    public interface IOrderMedService

    {

        public List<GetAllOrderMedsByOrderID> GetAllOrderMedicineByOrderID(decimal id);
        List<Ordermed> GetAllOrdermeds();
        Ordermed GetOrdermedById(decimal id);
        void CreateOrdermed(Ordermed ordermedData);
        void UpdateOrdermed(Ordermed ordermedData);
        void DeleteOrdermed(decimal id);
    }
}
