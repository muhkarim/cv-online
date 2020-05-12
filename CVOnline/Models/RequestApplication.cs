using CVOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Models
{
    [Table("TB_T_RequestApplication")]
    public class RequestApplication : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

        public int Jobs_Id { get; set; }
        public Job Jobs { get; set; }

        public IList<UserRequest> UserRequests { get; set; }
    }
}
