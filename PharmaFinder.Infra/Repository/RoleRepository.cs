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
    public class RoleRepository:IRoleRepository
    {
        private readonly IDbContext dbContext;

        public RoleRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Role> GetAllRoles()
        {
            IEnumerable<Role> result = dbContext.Connection.Query<Role>("role_package.GetAllRoles", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Role GetRoleById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("Role_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Role>("role_package.GetRoleById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateRole(Role roleData)
        {
            var p = new DynamicParameters();
            p.Add("Role_Name", roleData.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("role_package.CreateRole", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateRole(Role roleData)
        {
            var p = new DynamicParameters();
            p.Add("Role_ID", roleData.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Role_Name", roleData.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("role_package.UpdateRole", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteRole(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("Role_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("role_package.DeleteRole", p, commandType: CommandType.StoredProcedure);
        }
    }
}
