using CVOnline.Context;
using CVOnline.Models;
using CVOnline.ViewModels;
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
    public class RequestRepository : GeneralRepository<Request, MyContext>
    {
        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }
        private readonly MyContext _myContext;
        public RequestRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            _myContext = myContext;
            _configuration = configuration;
        }

        public async Task<IEnumerable<RequestAllVM>> GetAllRequest()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
            {
                var spName = "SP_View_Request";
                
                var data = await connection.QueryAsync<RequestAllVM>(spName, commandType: CommandType.StoredProcedure);
                return data;
            }
        }


        public async Task<IEnumerable<RequestVM>> GetAllRequestById(int RequestId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
            {
                var spName = "SP_View_Request_ByIdRequest";
                parameters.Add("@RequestId", RequestId);
                var data = await connection.QueryAsync<RequestVM>(spName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }


    }
}
