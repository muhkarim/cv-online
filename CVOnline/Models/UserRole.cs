using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Models
{
    [Table("TB_M_UserRole")]
    public class UserRole
    {
        public int User_Id { get; set; } // foreign key
        public User User { get; set; } // reference navigation property

        public int Role_Id { get; set; } // foreign key
        public Role Role { get; set; } // reference navigation property


    }
}
