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
    public class UserRepository:IUserRepository
    {
        private readonly IDbContext dbContext;

        public UserRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<User> GetAllUsers()
        {
            IEnumerable<User> result = dbContext.Connection.Query<User>("users_package.GetAllUsers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<AllUsersEmails> GetAllUsersEmail()
        {
            IEnumerable<AllUsersEmails> result = dbContext.Connection.Query<AllUsersEmails>("users_package.GetAllUsersEmail", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public int GetUserCount()
        {
            var result = dbContext.Connection.ExecuteScalar<int>("users_package.GetUserCount", commandType: CommandType.StoredProcedure);
            return result;
        }


        public User GetUserById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("User_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<User>("users_package.GetUserById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }



        public void CreateUser(User userData)
        {
            var p = new DynamicParameters();
            p.Add("Role_ID", userData.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Profile_Image", userData.Profileimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("User_Name", userData.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Password_", userData.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Email_", userData.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Gender_", userData.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DateOf_Birth", userData.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("Address_", userData.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Phone_Number", userData.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("users_package.CreateUser", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateUser(User userData)
        {
            var p = new DynamicParameters();
            p.Add("User_ID", userData.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Role_ID", userData.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Profile_Image", userData.Profileimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("User_Name", userData.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Password_", userData.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Email_", userData.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Gender_", userData.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DateOf_Birth", userData.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("Address_", userData.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Phone_Number", userData.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("users_package.UpdateUser", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteUser(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("User_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("users_package.DeleteUser", p, commandType: CommandType.StoredProcedure);
        }
    }


}

