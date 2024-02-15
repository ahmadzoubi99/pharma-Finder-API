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
    public class AboutRepository : IAboutRepository
    {
        private readonly IDbContext dbContext;

        public AboutRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<About> GetAllAbouts()
        {
            IEnumerable<About> result = dbContext.Connection.Query<About>("about_package.GetAllAbouts", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public About GetAboutById(decimal aboutId)
        {
            var p = new DynamicParameters();
            p.Add("p_aboutId", aboutId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<About>("about_package.GetAboutById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateAbout(About aboutData)
        {
            var p = new DynamicParameters();
            p.Add("p_heading1", aboutData.Heading1, DbType.String, ParameterDirection.Input);
            p.Add("p_content1", aboutData.Content1, DbType.String, ParameterDirection.Input);
            p.Add("p_image1", aboutData.Image1, DbType.String, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("about_package.CreateAbout", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateAbout(About aboutData)
        {
            var p = new DynamicParameters();
            p.Add("p_aboutId", aboutData.Aboutid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_heading1", aboutData.Heading1, DbType.String, ParameterDirection.Input);
            p.Add("p_content1", aboutData.Content1, DbType.String, ParameterDirection.Input);
            p.Add("p_image1", aboutData.Image1, DbType.String, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("about_package.UpdateAbout", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteAbout(decimal aboutId)
        {
            var p = new DynamicParameters();
            p.Add("p_aboutId", aboutId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("about_package.DeleteAbout", p, commandType: CommandType.StoredProcedure);
        }
    }
}
