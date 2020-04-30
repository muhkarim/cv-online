using CVOnline.Context;
using CVOnline.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Repositories.Data
{
    public class RoleRepository : GeneralRepository<Role, MyContext>
    {
        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }
        public RoleRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserRole>> InsertUserRole(int user_id, int role_id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
            {
                var spName = "SP_Insert_UserRole";
                parameters.Add("@UserId", user_id);
                parameters.Add("@RoleId", role_id);
                var data = await connection.QueryAsync<UserRole>(spName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }





    }
}
