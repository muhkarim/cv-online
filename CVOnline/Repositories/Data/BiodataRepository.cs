using CVOnline.Context;
using CVOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Repositories.Data
{
    public class BiodataRepository : GeneralRepository<Biodata, MyContext>
    {
        public BiodataRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
