using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Models
{
    [Table("TB_M_EducationalDetails")]
    public class EducationalDetails
    {
        [Key]
        public int Id { get; set; }
        public string Level { get; set; }
        public string Name { get; set; }
        public string Majors { get; set; }
        public string YearOfEntry { get; set; }
        public string GraduationYear { get; set; }
        public string Place { get; set; }
        public string FinalValue { get; set; }

        public Applicant Applicant { get; set; }
    }
}
