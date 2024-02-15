using Dapper;
using PharmaFinder.Core.Common;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PharmaFinder.Infra.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly IDbContext dbContext;
     
        public BankRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Bank> GetAllBanks()
        {
            IEnumerable<Bank> result = dbContext.Connection.Query<Bank>("Bank_Package.GetAllBanks", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Bank GetBankById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, DbType.Decimal, ParameterDirection.Input);
            var result = dbContext.Connection.QueryFirstOrDefault<Bank>("Bank_Package.GetBankById", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public void CreateBank(Bank bankData)
        {
            var p = new DynamicParameters();
            p.Add("CARDHOLDER", bankData.Cardholder, DbType.String, ParameterDirection.Input);
            p.Add("CARDNUMBER", bankData.Cardnumber, DbType.Decimal, ParameterDirection.Input);
            p.Add("CVV", bankData.Cvv, DbType.Decimal, ParameterDirection.Input);
            p.Add("EXPIREDATE", bankData.Expiredate, DbType.Date, ParameterDirection.Input);
            p.Add("BALANCE", bankData.Balance, DbType.Decimal, ParameterDirection.Input);
            dbContext.Connection.Execute("Bank_Package.CreateBank", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateBank(Bank bankData)
        {
            var p = new DynamicParameters();
            p.Add("ID", bankData.Bankid, DbType.Decimal, ParameterDirection.Input);
            p.Add("CARDHOLDER", bankData.Cardholder, DbType.String, ParameterDirection.Input);
            p.Add("CARDNUMBER", bankData.Cardnumber, DbType.Decimal, ParameterDirection.Input);
            p.Add("CVV", bankData.Cvv, DbType.Decimal, ParameterDirection.Input);
            p.Add("EXPIREDATE", bankData.Expiredate, DbType.Date, ParameterDirection.Input);
            p.Add("BALANCE", bankData.Balance, DbType.Decimal, ParameterDirection.Input);
            dbContext.Connection.Execute("Bank_Package.UpdateBank", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteBank(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, DbType.Decimal, ParameterDirection.Input);
            dbContext.Connection.Execute("Bank_Package.DeleteBank", p, commandType: CommandType.StoredProcedure);
        }
    }
}
