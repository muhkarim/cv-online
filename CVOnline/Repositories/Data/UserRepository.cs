using CVOnline.Context;
using CVOnline.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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



    }
}
