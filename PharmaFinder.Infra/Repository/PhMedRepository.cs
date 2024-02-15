using Dapper;
using PharmaFinder.Core.Common;
using PharmaFinder.Core.Data;
using PharmaFinder.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaFinder.Infra.Repository
{
    public class PhMedRepository: IPhMedRepsitory
    {
        private readonly IDbContext dbContext;
        public PhMedRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void CreatephMed(Phmed phmed)
        {
            var p = new DynamicParameters();
            p.Add("PHARMACY_ID",phmed.Pharmacyid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MEDICINE_ID", phmed.Medicineid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("QUANTITY_", phmed.Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("phmed_package.CreatephMed", p, commandType: CommandType.StoredProcedure);


        }
    }
}
