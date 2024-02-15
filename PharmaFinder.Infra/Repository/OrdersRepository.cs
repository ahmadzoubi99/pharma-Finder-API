using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using PharmaFinder.Core.Common;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PharmaFinder.Infra.Repository
{
    public class OrdersRepository:IOrdersRepository
    {
        private readonly IDbContext dbContext;

        public OrdersRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;

        }


        public int CalculateTotalOrderPrice()
        {
            var result = dbContext.Connection.ExecuteScalar<int>("orders_package.CalculateTotalOrderPrice", commandType: CommandType.StoredProcedure);
            return result;
        }

        public List<ProfitDTO> CalculateProfitForPaidOrders()
        {
            var result = dbContext.Connection.Query<ProfitDTO>("orders_package.CalculateProfitForPaidOrders", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<AnnualProfitDTO> CalculateAnnualProfitForPaidOrders()
        {
            var result = dbContext.Connection.Query<AnnualProfitDTO>("orders_package.CalculateAnnualProfitForPaidOrders", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Order> GetAllOrders()
        {
            IEnumerable<Order> result = dbContext.Connection.Query<Order>("orders_package.GetAllOrders", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
     
        public List<GetALLInformationOrders> GetAllInformationOrders()
        {
            IEnumerable<GetALLInformationOrders> result = dbContext.Connection.Query<GetALLInformationOrders>("orders_package.GetAllOrdersAndOrderMed", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Order GetOrderById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("p_OrderID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Order>("orders_package.GetOrderById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public List<Order> GetOrdersByUserId(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("p_UserID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Order>("orders_package.GetOrderByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public int CreateOrder(Order orderData)
        {
            var p = new DynamicParameters();
            p.Add("UserID", orderData.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("OrderPrice", orderData.Orderprice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("NewOrderID", dbType: DbType.Int32, direction: ParameterDirection.Output); 

            var result = dbContext.Connection.Execute("orders_package.CreateOrder", p, commandType: CommandType.StoredProcedure);

            int newOrderID = p.Get<int>("NewOrderID");

            return newOrderID;
        }

        public void UpdateOrder(Order orderData)
        {
            var p = new DynamicParameters();
            p.Add("OrderID", orderData.Orderid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("UserID", orderData.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PharmacyID", orderData.Pharmacyid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("OrderDate", orderData.Orderdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("Approval", orderData.Approval, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("OrderPrice", orderData.Orderprice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("orders_package.UpdateOrder", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteOrder(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("OrdID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("orders_package.DeleteOrder", p, commandType: CommandType.StoredProcedure);
        }
        public void AcceptOrRejectOrders( Order order)
        {
            var p = new DynamicParameters();
            p.Add("ordersID", order.Orderid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("approvalOrders", order.Approval, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("orders_package.AcceptOrRejectOrders", p, commandType: CommandType.StoredProcedure);

        }
        public void AcceptOrRejectPayment(Order order)
        {
            var p = new DynamicParameters();
            p.Add("p_OrderID", order.Orderid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("statusOrders", order.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("orders_package.AcceptOrRejectPayment", p, commandType: CommandType.StoredProcedure);

        }




        public List<PharmacySalesSearch> SalesSearch(PharmacySalesSearch search)
        {
            var p = new DynamicParameters();
            p.Add("DateFrom", search.DateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("DateTo", search.DateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<PharmacySalesSearch>("orders_package.SalesSearch", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IEnumerable<MonthlySalesReport>> GetMonthlySalesReport(int month, int year)
        {
           
                var p = new DynamicParameters();
                p.Add("p_month", month, DbType.Int32, ParameterDirection.Input);
                p.Add("p_year", year, DbType.Int32, ParameterDirection.Input);

                var result = await dbContext.Connection.QueryAsync<MonthlySalesReport>("orders_package.MonthlySalesReport", p, commandType: CommandType.StoredProcedure);

            return result;
         
        }

        public async Task<IEnumerable<AnnualSalesReport>> GetAnnualSalesReport(int year)
        {

            var p = new DynamicParameters();
            p.Add("p_year", year, DbType.Int32, ParameterDirection.Input);

            var result = await dbContext.Connection.QueryAsync<AnnualSalesReport>("orders_package.AnnualSalesReport", p, commandType: CommandType.StoredProcedure);

            return result;

        }

        public async Task<IEnumerable<AllSalesByMonthReport>> GetAllSalesByMonthReport(int month, int year)
        {
            var p = new DynamicParameters();
            p.Add("p_OrderMonth", month, DbType.Int32, ParameterDirection.Input);
            p.Add("p_OrderYear", year, DbType.Int32, ParameterDirection.Input);  

            var result = await dbContext.Connection.QueryAsync<AllSalesByMonthReport>("orders_package.GetOrdersByMonth", p, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<AllSalesByYearReport>> GetAllSalesByYearReport(int year)
        {
            var p = new DynamicParameters();
            p.Add("p_OrderYear", year, DbType.Int32, ParameterDirection.Input);

            var result = await dbContext.Connection.QueryAsync<AllSalesByYearReport>("orders_package.GetOrdersByYear", p, commandType: CommandType.StoredProcedure);

            return result;
        }
        public void ProcessPayment(int OrderdID,Bank bank)
        {
            var p=new DynamicParameters();
            p.Add("p_OrderID", OrderdID, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CardHolder", bank.Cardholder, DbType.String, direction: ParameterDirection.Input);
            p.Add("p_CardNumber", bank.Cardnumber, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_CVV", bank.Cvv, DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("orders_package.ProcessPayment", p, commandType: CommandType.StoredProcedure);



        }
        public List<SalesSearch2> SalesSearch2(SalesSearch2 search)
        {
            var p =new DynamicParameters();
            p.Add("DateTo", search.DateTo, DbType.Date, direction: ParameterDirection.Input);
            p.Add("DateFrom", search.DateFrom, DbType.Date, direction: ParameterDirection.Input);
            IEnumerable<SalesSearch2> result = dbContext.Connection.Query<SalesSearch2>("orders_package.SalesSearch2", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }

    
}
