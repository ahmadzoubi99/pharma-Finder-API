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
    public class LoginRepository:ILoginRepository
    {
        private readonly IDbContext dbContext;
        public LoginRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User GenerateToken(User users)
        {
            var p = new DynamicParameters();
            p.Add("User_NAME", users.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", users.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<User> result = dbContext.Connection.Query<User>("Login_Package.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }
    }
}
