using CVOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Models
{
    [Table("TB_M_WorkExperience")]
    public class WorkExperience : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string LastPosition { get; set; }
        public string TypeOfBussiness { get; set; }
        public string YearStartedWorking { get; set; }
        public string YearOfResign { get; set; }
        public string LastSalary { get; set; }

        public Applicant Applicant { get; set; }

    }
}
