using Dapper;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Service;
using System.Data;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;

        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [Route("GetAllInformationOrders")]
        public List<GetALLInformationOrders> GetAllInformationOrders()
        {
            return _orderService.GetAllInformationOrders();
        }

        [HttpGet]
        [Route("CalculateTotalOrderPrice")]
        public int CalculateTotalOrderPrice()
        {
            return _orderService.CalculateTotalOrderPrice();
        }

        [HttpGet]
        [Route("CalculateProfitForPaidOrders")]
        public List<ProfitDTO> CalculateProfitForPaidOrders()
        {
            return _orderService.CalculateProfitForPaidOrders();

        }

        [HttpGet]
        [Route("CalculateAnnualProfitForPaidOrders")]
        public List<AnnualProfitDTO> CalculateAnnualProfitForPaidOrders()
        {
            return _orderService.CalculateAnnualProfitForPaidOrders();

        }

        [HttpGet]
        [Route("GetAllOrders")]
        public List<Order> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }


        [HttpGet]
        [Route("GetOrderById/{id}")]
        public Order GetOrderById(decimal id)
        {
            return _orderService.GetOrderById(id);
        }
        [HttpGet]
        [Route("GetOrdersByUserId/{id}")]
        public List<Order> GetOrdersByUserId(decimal id)
        {
            return _orderService.GetOrdersByUserId(id);

        }


        [HttpPost]
        [Route("CreateOrder")]
        public IActionResult CreateOrder(Order order)
        {
            int orderid= _orderService.CreateOrder(order);
            return StatusCode(201, orderid);
        }
        [HttpPost]
        [Route("ProcessPayment")]
        public void ProcessPayment(int OrderdID,Bank bank)
        {
            _orderService.ProcessPayment(OrderdID,bank);

        }


        [HttpPut]
        [Route("UpdateOrder")]
        public IActionResult UpdateOrder( Order order)
        {
            _orderService.UpdateOrder(order);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteOrder/{id}")]
        public IActionResult DeleteOrder(decimal id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }

        [HttpPut]
        [Route("AcceptOrRejectOrders")]
        public void AcceptOrRejectOrders(Order order)
        {
            _orderService.AcceptOrRejectOrders(order);

        }
        [HttpPut]
        [Route("AcceptOrRejectPayment")]
        public void AcceptOrRejectPayment(Order order)
        {
            _orderService.AcceptOrRejectPayment(order);

        }


        [HttpPost]
        [Route("SalesSearch")]

        public List<PharmacySalesSearch> SalesSearch(PharmacySalesSearch search)
        {
            return _orderService.SalesSearch(search);
        }

        [HttpPost]
        [Route("MonthlySalesReport")]
       
        public async Task<IEnumerable<MonthlySalesReport>> GetMonthlySalesReport(int month, int year)
        {
            return await _orderService.GetMonthlySalesReport(month,year);

        }

        [HttpPost]
        [Route("AnnualSalesReport")]
        public async Task<IEnumerable<AnnualSalesReport>> GetAnnualSalesReport(int year)
        {
            return await _orderService.GetAnnualSalesReport(year);
        }

        [HttpPost]
        [Route("AllSalesByMonthReport")]
        public async Task<IEnumerable<AllSalesByMonthReport>> GetAllSalesByMonthReport(int month, int year)
        {
            return await _orderService.GetAllSalesByMonthReport(month, year);
        }

        [HttpPost]
        [Route("AllSalesByYearReport")]
        public async Task<IEnumerable<AllSalesByYearReport>> GetAllSalesByYearReport(int year)
        {
            return await _orderService.GetAllSalesByYearReport(year);
        }

        [HttpGet("download-Monthly-pdf")]
        public async Task<IActionResult> DownloadMonthlyPdfReport(int month, int year)
        {
            try
            {
                var pdfBytes = await _orderService.GenerateMonthlyPdfReport(month, year);

                return File(pdfBytes, "application/pdf", "monthly_sales_report.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("download-Annual-pdf")]
        public async Task<IActionResult> DownloadAnnualPdfReport(int year)
        {
            try
            {
                var pdfBytes = await _orderService.GenerateAnnualPdfReport(year);

                return File(pdfBytes, "application/pdf", "Annual_sales_report.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("SalesSearch2")]
        public List<SalesSearch2> SalesSearch2(SalesSearch2 search)
        {
            return _orderService.SalesSearch2(search);
        }

    }
}