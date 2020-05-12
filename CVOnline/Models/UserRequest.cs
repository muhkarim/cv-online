using CVOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Models
{
    [Table("TB_T_Request")]
    public class UserRequest : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int Applicants_Id { get; set; }
        public Applicant Applicant { get; set; }
        public int Jobs_Id { get; set; }
        public Job Jobs { get; set; }

        public string Status { get; set; }
        public DateTime CreateDate { get; set; }


    }
}
