using Dapper;
using PharmaFinder.Core.Common;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Repository
{
    public class OrderMedRepository:IOrderMedRepository
    {
        private readonly IDbContext dbContext;

        public OrderMedRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Ordermed> GetAllOrdermeds()
        {
            IEnumerable<Ordermed> result = dbContext.Connection.Query<Ordermed>("OrderMed_Package.GetAllOrdermeds", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Ordermed GetOrdermedById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("OrderMedID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Ordermed>("OrderMed_Package.GetOrdermedById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public List<GetAllOrderMedsByOrderID> GetAllOrderMedicineByOrderID(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<GetAllOrderMedsByOrderID> result = dbContext.Connection.Query<GetAllOrderMedsByOrderID>(
                "OrderMed_Package.GetAllOrderMedsByOrderId",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

        public void CreateOrdermed(Ordermed ordermedData)
        {
            var p = new DynamicParameters();
            p.Add("MedicineID", ordermedData.Medicineid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("PharmacyID", ordermedData.Pharmacyid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("OrderID", ordermedData.Orderid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Quantity", ordermedData.Quantity, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("OrderMed_Package.CreateOrdermed", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateOrdermed(Ordermed ordermedData)
        {
            var p = new DynamicParameters();
            p.Add("OrderMedID", ordermedData.Ordermedid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("MedicineID", ordermedData.Medicineid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("OrderID", ordermedData.Orderid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Quantity", ordermedData.Quantity, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("OrderMed_Package.UpdateOrdermed", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteOrdermed(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("OrdMedID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("OrderMed_Package.DeleteOrdermed", p, commandType: CommandType.StoredProcedure);
        }
    }
}
