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
    public class HomeRepository : IHomeRepository
    {
        private readonly IDbContext dbContext;

        public HomeRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Home> GetAllHomes()
        {
            IEnumerable<Home> result = dbContext.Connection.Query<Home>("home_package.GetAllHomes", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Home GetHomeById(decimal homeId)
        {
            var p = new DynamicParameters();
            p.Add("p_homeId", homeId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<Home>("home_package.GetHomeById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateHome(Home homeData)
        {
            var p = new DynamicParameters();
            p.Add("p_heading1", homeData.Heading1, DbType.String, ParameterDirection.Input);
            p.Add("p_content1", homeData.Content1, DbType.String, ParameterDirection.Input);
            p.Add("p_image1", homeData.Image1, DbType.String, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("home_package.CreateHome", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateHome(Home homeData)
        {
            var p = new DynamicParameters();
            p.Add("p_homeId", homeData.Homeid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_heading1", homeData.Heading1, DbType.String, ParameterDirection.Input);
            p.Add("p_content1", homeData.Content1, DbType.String, ParameterDirection.Input);
            p.Add("p_image1", homeData.Image1, DbType.String, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("home_package.UpdateHome", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteHome(decimal homeId)
        {
            var p = new DynamicParameters();
            p.Add("p_homeId", homeId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("home_package.DeleteHome", p, commandType: CommandType.StoredProcedure);
        }
    }
}
