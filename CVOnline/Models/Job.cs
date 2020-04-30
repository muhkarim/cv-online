using CVOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Models
{
    [Table("TB_M_Jobs")]
    public class Job : IEntity
    {

            public int Id { get; set; }
            public string JobName { get; set; }
            public bool isActive { get; set; }
            public Nullable<DateTimeOffset> DueDate { get; set; }
        
    }
}
