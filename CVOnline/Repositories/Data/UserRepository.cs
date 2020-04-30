using CVOnline.Context;
using CVOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Repositories.Data
{
    public class UserRepository : GeneralRepository<User, MyContext>
    {
        public UserRepository(MyContext myContext) : base(myContext) { }
    }
}
