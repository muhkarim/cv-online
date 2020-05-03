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
        public EducationalDetailsRepository(MyContext myContext) : base(myContext) { }

    }
}
