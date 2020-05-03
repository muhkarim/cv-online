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
    public class UserRepository : GeneralRepository<User, MyContext>
    {
        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }
        private readonly MyContext _myContext;

        public UserRepository(MyContext myContext, IConfiguration configuration) : base(myContext) 
        {
            _myContext = myContext;
            _configuration = configuration;
        }


        public User GetByEmail(string email)
        {
            return _myContext.Users.Where(s => s.Email == email).FirstOrDefault();
        }


        //// Get All Users
        //public async Task<IEnumerable<UserVM>> Get()
        //{
        //    using (var connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
        //    {
        //        var spName = "SP_GetAll_Users";
        //        var data = await connection.QueryAsync<UserVM>(spName, commandType: CommandType.StoredProcedure);
        //        return data;
        //    }
        //}

        //// GetById
        //public async Task<IEnumerable<UserVM>> GetById(int id) 
        //{
        //    using (var connection = new SqlConnection(_configuration.GetConnectionString("MyConnection")))
        //    {
        //        var spName = "SP_GetById_Users";
        //        parameters.Add("@id", id);
        //        var data = await connection.QueryAsync<UserVM>(spName, parameters, commandType: CommandType.StoredProcedure);
        //        return data;
        //    }
        //}



    }
}
