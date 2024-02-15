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
    public class UserTestmonialRepository:IUserTestmonialRepository
    {
        private readonly IDbContext dbContext;

        public UserTestmonialRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Usertestimonial> GetAllUsertestimonials()
        {
            IEnumerable<Usertestimonial> result = dbContext.Connection.Query<Usertestimonial>("user_testimonial_package.GetAllUsertestimonials", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Usertestimonial GetUsertestimonialById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("UTestimonial_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Usertestimonial>("user_testimonial_package.GetUsertestimonialById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateUsertestimonial(Usertestimonial usertestimonialData)
        {
            var p = new DynamicParameters();
            p.Add("User_ID", usertestimonialData.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Testimonial_Text", usertestimonialData.Testimonialtext, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("user_testimonial_package.CreateUsertestimonial", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateUsertestimonial(Usertestimonial usertestimonialData)
        {
            var p = new DynamicParameters();
            p.Add("UTestimonial_ID", usertestimonialData.Utestimonialid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("User_ID", usertestimonialData.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Testimonial_Text", usertestimonialData.Testimonialtext, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STATUS_", usertestimonialData.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("user_testimonial_package.UpdateUsertestimonial", p, commandType: CommandType.StoredProcedure);
        }
        public void AcceptOrRejectTestimonial(Usertestimonial usertestimonialData)
        {
            var p = new DynamicParameters();
            p.Add("ID", usertestimonialData.Utestimonialid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("status_", usertestimonialData.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("user_testimonial_package.UpdateUsertestimonial", p, commandType: CommandType.StoredProcedure);
        }
        public void DeleteUsertestimonial(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("UTestimonial_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("user_testimonial_package.DeleteUsertestimonial", p, commandType: CommandType.StoredProcedure);
        }
    }
}
