using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Models
{
    [Table("TB_T_UserRequest")]
    public class UserRequest
    {
        [Key]
        public int Id { get; set; }

        public Applicant Applicant { get; set; }
        public int Applicants_Id { get; set; }

        public RequestApplication RequestApplication { get; set; }
        public int RequestApplication_Id { get; set; }


    }
}
