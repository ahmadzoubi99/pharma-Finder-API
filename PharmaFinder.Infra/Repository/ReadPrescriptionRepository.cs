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
    public class ReadPrescriptionRepository: IReadPrescriptionRepository
    {
        private readonly IDbContext dbContext;

        public ReadPrescriptionRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<PharmaMedResult> GetMedicineDetails(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("p_medID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            IEnumerable<PharmaMedResult> result = dbContext.Connection.Query<PharmaMedResult>("phmed_package.GetMedicineDetails", p,commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


    }
}
