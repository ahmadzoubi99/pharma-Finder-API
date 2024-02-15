using PharmaFinder.Core.Data;
using PharmaFinder.Core.Service;
using PharmaFinder.Core.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaFinder.Core.DTO;
using Dapper;
using System.Data;
using DinkToPdf.Contracts;
using DinkToPdf;

namespace PharmaFinder.Infra.Service
{
    public class OrdersService:IOrdersService
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly IConverter _pdfConverter;
        public OrdersService(IOrdersRepository orderRepository, IConverter pdfConverter)
        {
            _orderRepository = orderRepository;
            _pdfConverter = pdfConverter;
        }
        public int CalculateTotalOrderPrice()
        {
            return _orderRepository.CalculateTotalOrderPrice();
        }

        public List<ProfitDTO> CalculateProfitForPaidOrders()
        {
            return _orderRepository.CalculateProfitForPaidOrders();

        }

        public List<AnnualProfitDTO> CalculateAnnualProfitForPaidOrders()
        {
            return _orderRepository.CalculateAnnualProfitForPaidOrders();
        }
        public List<GetALLInformationOrders> GetAllInformationOrders()
        {
            return _orderRepository.GetAllInformationOrders();
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order GetOrderById(decimal id)
        {
            return _orderRepository.GetOrderById(id);
        }
        public List<Order> GetOrdersByUserId(decimal id)
        {
            return _orderRepository.GetOrdersByUserId(id);
        }
        public int CreateOrder(Order orderData)
        {
            return _orderRepository.CreateOrder(orderData);
        }

        public void UpdateOrder(Order orderData)
        {
            _orderRepository.UpdateOrder(orderData);
        }

        public void DeleteOrder(decimal id)
        {
            _orderRepository.DeleteOrder(id);
        }

        public void AcceptOrRejectOrders(Order order)
        {
            _orderRepository.AcceptOrRejectOrders(order); 
        }
        public void AcceptOrRejectPayment(Order order)
        {
            _orderRepository.AcceptOrRejectPayment(order);


        }
        public List<PharmacySalesSearch> SalesSearch(PharmacySalesSearch search)
        {
            return _orderRepository.SalesSearch(search);
        }

        public async Task<IEnumerable<MonthlySalesReport>> GetMonthlySalesReport(int month, int year)
        {
            return await _orderRepository.GetMonthlySalesReport(month, year);
        }

        public async Task<IEnumerable<AnnualSalesReport>> GetAnnualSalesReport(int year)
        {
            return await _orderRepository.GetAnnualSalesReport(year);
        }
        public async Task<IEnumerable<AllSalesByMonthReport>> GetAllSalesByMonthReport(int month, int year)
        {
            return await _orderRepository.GetAllSalesByMonthReport(month, year);
        }
        public async Task<IEnumerable<AllSalesByYearReport>> GetAllSalesByYearReport(int year)
        {
            return await _orderRepository.GetAllSalesByYearReport(year);
        }
        public void ProcessPayment(int OrderdID, Bank bank)
        {
            _orderRepository.ProcessPayment(OrderdID,bank); 
        }

        public async Task<byte[]> GenerateMonthlyPdfReport(int month, int year)
        {
            var data = await GetAllSalesByMonthReport(month, year);
            var htmlReport = GenerateMonthlyHtmlReport(data);

            var pdf = _pdfConverter.Convert(new HtmlToPdfDocument()
            {
                GlobalSettings = {
            PaperSize = PaperKind.A4,
            Orientation = Orientation.Landscape
        },
                Objects = {
            new ObjectSettings() {
                HtmlContent = htmlReport
            }
        }
            });

            return pdf;
        }

        private string GenerateMonthlyHtmlReport(IEnumerable<AllSalesByMonthReport> data)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            // Start HTML document
            htmlBuilder.Append("<html><head><title>Monthly Sales Report</title>");
            htmlBuilder.Append("<style>");
            // Add CSS styles for a better design
            htmlBuilder.Append("body { font-family: 'Arial', sans-serif; color: #333; text-align: center; }");
            htmlBuilder.Append(".report-container { max-width: 1800px; margin: 100px auto; text-align: center; padding: 100px; border: 10px solid #007bff; }"); // Container for the report
            htmlBuilder.Append(".logo-container {text-align: left; max-width: 240px; background-color: #007bff; padding: 10px; border-radius: 45px 5px 45px 5px; margin-bottom: 100px; }"); // Container for the logo
            htmlBuilder.Append(".logo {text-align: left; font-family: sans-serif; font-size: 36px; color: #fff }"); // Styles for the logo
            htmlBuilder.Append("h1 { color: #00008b; margin-top: 20px; margin-bottom: 80px;}"); // Blue color for the header
            htmlBuilder.Append("h1::after { content: ''; display: block; width: 400px; height: 2px; background-color: #00008b; margin: 10px auto; }"); // Line under the header
            htmlBuilder.Append("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            htmlBuilder.Append("th, td { padding: 10px; border: 1px solid #ddd; text-align: left; }");
            htmlBuilder.Append("th { background-color: #87cefa; }");
            htmlBuilder.Append("</style>");
            htmlBuilder.Append("</head><body>");

            // Add the report container
            htmlBuilder.Append("<div class='report-container'>");

            // Add the logo container
            htmlBuilder.Append("<div class='logo-container'>");
            // Add the logo inside the logo container
            htmlBuilder.Append("<div class='logo'>PharmaFinder</div>");
            htmlBuilder.Append("</div>");

            // Add a centered header with a line under it
            htmlBuilder.Append("<h1>Monthly Sales Report</h1>");

            // Add a table to display sales data
            htmlBuilder.Append("<table>");
            htmlBuilder.Append("<tr><th>Order Date</th><th>Pharmacy Name</th><th>Quantity</th><th>Order Price</th></tr>");

            foreach (var sale in data)
            {
                htmlBuilder.Append("<tr>");
                htmlBuilder.Append($"<td>{sale.Orderdate}</td>");
                htmlBuilder.Append($"<td>{sale.Pharmacyname}</td>");
                htmlBuilder.Append($"<td>{sale.Quantity}</td>");
                htmlBuilder.Append($"<td>{sale.Orderprice}</td>");
                htmlBuilder.Append("</tr>");
            }

            // Close the table and HTML document
            htmlBuilder.Append("</table></body></html>");

            return htmlBuilder.ToString();
        }

        public async Task<byte[]> GenerateAnnualPdfReport(int year)
        {
            var data = await GetAllSalesByYearReport(year);
            var htmlReport = GenerateAnnualHtmlReport(data);

            var pdf = _pdfConverter.Convert(new HtmlToPdfDocument()
            {
                GlobalSettings = {
            PaperSize = PaperKind.A4,
            Orientation = Orientation.Landscape
        },
                Objects = {
            new ObjectSettings() {
                HtmlContent = htmlReport
            }
        }
            });

            return pdf;
        }

        private string GenerateAnnualHtmlReport(IEnumerable<AllSalesByYearReport> data)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            htmlBuilder.Append("<html><head><title>Annual Sales Report</title>");
            htmlBuilder.Append("<style>");
            // Add CSS styles for a better design
            htmlBuilder.Append("body { font-family: 'Arial', sans-serif; color: #333; text-align: center; }");
            htmlBuilder.Append(".report-container { max-width: 1800px; margin: 100px auto; text-align: center; padding: 100px; border: 10px solid #007bff; }"); // Container for the report
            htmlBuilder.Append(".logo-container {text-align: left; max-width: 240px; background-color: #007bff; padding: 10px; border-radius: 45px 5px 45px 5px; margin-bottom: 100px; }"); // Container for the logo
            htmlBuilder.Append(".logo {text-align: left; font-family: sans-serif; font-size: 36px; color: #fff }"); // Styles for the logo
            htmlBuilder.Append("h1 { color: #00008b; margin-top: 20px; margin-bottom: 80px;}"); // Blue color for the header
            htmlBuilder.Append("h1::after { content: ''; display: block; width: 400px; height: 2px; background-color: #00008b; margin: 10px auto; }"); // Line under the header
            htmlBuilder.Append("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            htmlBuilder.Append("th, td { padding: 10px; border: 1px solid #ddd; text-align: left; }");
            htmlBuilder.Append("th { background-color: #87cefa; }");
            htmlBuilder.Append("</style>");
            htmlBuilder.Append("</head><body>");

            // Add the report container
            htmlBuilder.Append("<div class='report-container'>");

            // Add the logo container
            htmlBuilder.Append("<div class='logo-container'>");
            // Add the logo inside the logo container
            htmlBuilder.Append("<div class='logo'>PharmaFinder</div>");
            htmlBuilder.Append("</div>");

            // Add a centered header with a line under it
            htmlBuilder.Append("<h1>Annual Sales Report</h1>");

            // Add a table to display sales data
            htmlBuilder.Append("<table>");
            htmlBuilder.Append("<tr><th>Order Date</th><th>Pharmacy Name</th><th>Quantity</th><th>Order Price</th></tr>");

            foreach (var sale in data)
            {
                htmlBuilder.Append("<tr>");
                htmlBuilder.Append($"<td>{sale.Orderdate}</td>");
                htmlBuilder.Append($"<td>{sale.Pharmacyname}</td>");
                htmlBuilder.Append($"<td>{sale.Quantity}</td>");
                htmlBuilder.Append($"<td>{sale.Orderprice}</td>");
                htmlBuilder.Append("</tr>");
            }

            // Close the table and HTML document
            htmlBuilder.Append("</table></body></html>");

            return htmlBuilder.ToString();
        }

        public List<SalesSearch2> SalesSearch2(SalesSearch2 search)
        {
            return _orderRepository.SalesSearch2(search);
        }

    }
}
