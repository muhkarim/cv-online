using CVOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Models
{
   
        [Table("TB_M_Roles")]
        public class Role : IEntity
        {
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }

            public IList<UserRole> UserRoles { get; set; } //collection navigation property
        
    }
}
