using CVOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Models
{
    [Table("TB_M_Applicants")]

    public class Applicant : IEntity
    {
        public int Id { get; set; }

        public int Document_Id { get; set; }
        public Document Document { get; set; }

        public int EducationalDetails_Id { get; set; }
        public EducationalDetails EducationalDetails { get; set; }

        public int Biodata_Id { get; set; }
        public Biodata Biodata { get; set; }

        public int User_Id { get; set; }
        public User User { get; set; }

        public int WorkExperience_Id { get; set; }
        public WorkExperience WorkExperience { get; set; }

        public IList<UserRequest> UserRequests { get; set; }
    }
}
