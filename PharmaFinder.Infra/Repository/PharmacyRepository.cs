using Dapper;
using MailKit.Search;
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
    public class PharmacyRepository:IPharmacyRepository
    {
        private readonly IDbContext dbContext;

        public int GetPharmacyCount()
        {
            var result = dbContext.Connection.ExecuteScalar<int>("Pharmacy_Package.GetpharmacyCount", commandType: CommandType.StoredProcedure);
            return result;
        }
        public PharmacyRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Pharmacy> GetAllPharmacies()
        {
            IEnumerable<Pharmacy> result = dbContext.Connection.Query<Pharmacy>("Pharmacy_Package.GetAllPharmacies", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Pharmacy GetPharmacyById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Pharmacy>("Pharmacy_Package.GetPharmacyById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreatePharmacy(Pharmacy pharmacyData)
        {
            var p = new DynamicParameters();
            p.Add("Pharmacy_Name", pharmacyData.Pharmacyname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Location_", pharmacyData.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Address_", pharmacyData.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Lng_", pharmacyData.Lng, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Lat_", pharmacyData.Lat, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Email_", pharmacyData.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Phone_Number", pharmacyData.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Pharmacy_Package.CreatePharmacy", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdatePharmacy(Pharmacy pharmacyData)
        {
            var p = new DynamicParameters();
            p.Add("Pharmacy_ID", pharmacyData.Pharmacyid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Pharmacy_Name", pharmacyData.Pharmacyname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Location_", pharmacyData.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Address_", pharmacyData.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Lng_", pharmacyData.Lng, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Lat_", pharmacyData.Lat, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("Email_", pharmacyData.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Phone_Number", pharmacyData.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Pharmacy_Package.UpdatePharmacy", p, commandType: CommandType.StoredProcedure);
        }
        

        public void DeletePharmacy(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("Pharmacy_ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Pharmacy_Package.DeletePharmacy", p, commandType: CommandType.StoredProcedure);
        }

        public List<PharmacyNameSearch> SearchPharmacyName(PharmacyNameSearch search)
        {
            var p = new DynamicParameters();
            p.Add("Pharmacy_ID", search.Pharmacyname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<PharmacyNameSearch>("Pharmacy_Package.SearchPharmacyName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }



        //////////////
        ///


        public List<GetAllMedicineInPharmacy> GetAllMedcineInPharmmacy(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("idphar", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            // Pass the parameters to the stored procedure
            IEnumerable<GetAllMedicineInPharmacy> result = dbContext.Connection.Query<GetAllMedicineInPharmacy>(
                "User_Pharamcy.GETALLMEDCINEINPHARMMACY",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }


        public List<Order> GetAllOrdersInPharmmacy(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("idphar", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            IEnumerable<Order> result = dbContext.Connection.Query<Order>("User_Pharamcy.GETALLORDERSINPHARMMACY", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public int GetMedicineCountInPharmacy(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("idphar", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteScalar<int>("User_Pharamcy.GetMedcineCount", p, commandType: CommandType.StoredProcedure);

            return result;
        }

       public int SalesPharmacy(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("idphar", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteScalar<int>("User_Pharamcy.salesPharmacy", p, commandType: CommandType.StoredProcedure);
            return result;
        }
        

    public List<GetAllOrderMedsByOrderIdInPharmacy> GetAllOrderMedsByOrderIdInPharmacy(GetAllOrderMedsByOrderIdInPharmacy obj)
        {
            var p = new DynamicParameters();
            p.Add("ID", obj.ID, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("idphar", obj.idphar, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            IEnumerable<GetAllOrderMedsByOrderIdInPharmacy> result = dbContext.Connection.Query<GetAllOrderMedsByOrderIdInPharmacy>("User_Pharamcy.GetAllOrderMedsByOrderIdInPharm", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public List<SalesSearchInPharmacy> SalesSearch(SalesSearch2 search)
        {
            var p = new DynamicParameters();
            p.Add("idphar", search.idphar, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("DateTo", search.DateTo, DbType.Date, direction: ParameterDirection.Input);
            p.Add("DateFrom", search.DateFrom, DbType.Date, direction: ParameterDirection.Input);
            IEnumerable<SalesSearchInPharmacy> result = dbContext.Connection.Query<SalesSearchInPharmacy>("User_Pharamcy.SalesSearch", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        ////////////
        ///

        public void CreateMedcineInPharmacy(CreateMedcineInpharmacy createMedcineInpharmacy)
        {
            var p = new DynamicParameters();
            p.Add("Medicine_Name", createMedcineInpharmacy.Medicinename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHARMACY_ID", createMedcineInpharmacy.Pharmacyid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Medicine_Price", createMedcineInpharmacy.Medicineprice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("QUANTITY_", createMedcineInpharmacy.Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IMAGE_MEDICINE_", createMedcineInpharmacy.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Medicine_Type", createMedcineInpharmacy.Medicinetype, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Medicine_Description", createMedcineInpharmacy.Medicinedescription, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Expire_Date", createMedcineInpharmacy.Expiredate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("Active_Substance", createMedcineInpharmacy.Activesubstance, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("User_Pharamcy.CreateMedicine", p, commandType: CommandType.StoredProcedure);
        }

        public void updateMedcineInPharmacy(CreateMedcineInpharmacy updateMedcineInpharmacy)
        {
            var p = new DynamicParameters(); 
            p.Add("PHMED_ID", updateMedcineInpharmacy.Phmedid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Medicine_id", updateMedcineInpharmacy.Medicineid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Medicine_Name", updateMedcineInpharmacy.Medicinename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PHARMACY_ID", updateMedcineInpharmacy.Pharmacyid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Medicine_Price", updateMedcineInpharmacy.Medicineprice, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("QUANTITY_", updateMedcineInpharmacy.Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("IMAGE_MEDICINE_", updateMedcineInpharmacy.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Medicine_Type", updateMedcineInpharmacy.Medicinetype, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Medicine_Description", updateMedcineInpharmacy.Medicinedescription, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Expire_Date", updateMedcineInpharmacy.Expiredate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("Active_Substance", updateMedcineInpharmacy.Activesubstance, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("User_Pharamcy.updateMedcine", p, commandType: CommandType.StoredProcedure);
        }
    }
}
