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
    public class EducationalDetailsRepository : GeneralRepository<EducationalDetails, MyContext>
    {
        DynamicParameters parameters = new DynamicParameters();
        IConfiguration _configuration { get; }

        public EducationalDetailsRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            _configuration = configuration;
        }

    }
}
