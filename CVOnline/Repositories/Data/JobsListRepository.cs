using CVOnline.Context;
using CVOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Repositories.Data
{
    public class JobsListRepository : GeneralRepository<Job, MyContext>
    {
        public JobsListRepository(MyContext myContext) : base(myContext) { }
    }
}
