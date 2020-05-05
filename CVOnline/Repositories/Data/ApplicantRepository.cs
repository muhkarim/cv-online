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
    public class ApplicantRepository : GeneralRepository<Applicant, MyContext>
    {
        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }
        private readonly MyContext _myContext;
        public ApplicantRepository(MyContext myContext, IConfiguration configuration) : base (myContext)
        {
            _myContext = myContext;
            _configuration = configuration;
        }


        // Get All Applicant
        public async Task<IEnumerable<ApplicantVM>> Get()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
            {
                var spName = "SP_GetAll_Applicants";
                var data = await connection.QueryAsync<ApplicantVM>(spName, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

        // GetById
        public async Task<IEnumerable<ApplicantVM>> GetById(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
            {
                var spName = "SP_Applicant_Details";
                parameters.Add("@id", id);
                var data = await connection.QueryAsync<ApplicantVM>(spName, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }

       










    }
}
