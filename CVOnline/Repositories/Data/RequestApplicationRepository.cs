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
    public class RequestApplicationRepository : GeneralRepository<RequestApplication, MyContext>
    {

        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }
        public RequestApplicationRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            _configuration = configuration;
        }


        public async Task<IEnumerable<UserRole>> InsertUserRequest(int applicant_id, int requestapplication_id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
            {
                var spName = "SP_Insert_UserRequest";
                parameters.Add("@applicantId", applicant_id);
                parameters.Add("@requestapplicationId", requestapplication_id);
                var data = await connection.QueryAsync<UserRole>(spName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }



    }
}
