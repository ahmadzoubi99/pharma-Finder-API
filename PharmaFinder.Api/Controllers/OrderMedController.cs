using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Repository;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMedController : ControllerBase
    {
        private readonly IOrderMedService _orderMedService;

        public OrderMedController(IOrderMedService orderMedService)
        {
            _orderMedService = orderMedService;
        }

        [HttpGet]
        [Route("GetAllOrdermeds")]
        public List<Ordermed> GetAllOrdermeds()
        {
            return _orderMedService.GetAllOrdermeds();
        }

        [HttpGet]
        [Route("GetOrdermedById/{id}")]
        public Ordermed GetOrdermedById(decimal id)
        {
            return _orderMedService.GetOrdermedById(id);
        }
        [HttpGet]
        [Route("GetAllOrderMedByOrderID/{id}")]
        public List<GetAllOrderMedsByOrderID> GetAllOrderMedicineByOrderID(decimal id)
        {
            return _orderMedService.GetAllOrderMedicineByOrderID(id);
        }



        [HttpPost]
        [Route("CreateOrdermed/{orderid}")]
        public IActionResult CreateOrdermed(List<PharmaMedResult> orderList, int orderid)
        {
            try
            {
                foreach (var item in orderList)
                {
                    Ordermed order = new Ordermed
                    {
                        Orderid = orderid,
                        Medicineid = item.Medicineid,
                        Pharmacyid = (decimal)item.Pharmacyid,
                        Quantity = item.Quantity
                    };

                    _orderMedService.CreateOrdermed(order);
                }

                return StatusCode(201); 
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500); 
            }
        }
        [HttpPut]
        [Route("UpdateOrdermed")]
        public IActionResult UpdateOrdermed( Ordermed ordermed)
        {
            _orderMedService.UpdateOrdermed(ordermed);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteOrdermed/{id}")]
        public IActionResult DeleteOrdermed(decimal id)
        {
            _orderMedService.DeleteOrdermed(id);
            return Ok();
        }

    }
}
