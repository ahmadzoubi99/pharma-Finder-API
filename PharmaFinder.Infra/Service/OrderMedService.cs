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
    public class OrderMedService : IOrderMedService
    {
        private readonly IOrderMedRepository _orderMedRepository;

        public OrderMedService(IOrderMedRepository orderMedRepository)
        {
            _orderMedRepository = orderMedRepository;
        }

        public List<Ordermed> GetAllOrdermeds()
        {
            return _orderMedRepository.GetAllOrdermeds();
        }

        public Ordermed GetOrdermedById(decimal id)
        {
            return _orderMedRepository.GetOrdermedById(id);
        }
        public List<GetAllOrderMedsByOrderID> GetAllOrderMedicineByOrderID(decimal id)
        {
            return _orderMedRepository.GetAllOrderMedicineByOrderID(id);
        }


        public void CreateOrdermed(Ordermed ordermedData)
        {
            _orderMedRepository.CreateOrdermed(ordermedData);
        }

        public void UpdateOrdermed(Ordermed ordermedData)
        {
            _orderMedRepository.UpdateOrdermed(ordermedData);
        }

        public void DeleteOrdermed(decimal id)
        {
            _orderMedRepository.DeleteOrdermed(id);
        }


    }
}
