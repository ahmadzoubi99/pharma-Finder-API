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
    public class JWTRepository : IJWTRepository
    {
        private readonly IDbContext dbContext;
        public JWTRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User Auth(User user)
        {
            var p = new DynamicParameters();
            p.Add("E_mail", user.Email, dbType: DbType.String, direction: ParameterDirection.Input); ; p.Add("PASS", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<User> result = dbContext.Connection.Query<User>("users_package.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
       
    }
}
