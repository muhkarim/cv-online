using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Models
{
    [Table("TB_M_Document")]
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public string IdCard { get; set; }
        public string Resume { get; set; }
        public string CV { get; set; }
        public string FamilyCard { get; set; }
        public string Transcripts { get; set; }
        public string Diploma { get; set; }
        public string Certificate { get; set; }

        public Applicant Applicant { get; set; }
    }
}
