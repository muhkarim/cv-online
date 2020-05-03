using CVOnline.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.Models
{
    [Table("TB_M_Document")]
    public class Document : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string fIdCard { get; set; }
        public string fResume { get; set; }
        public string fCV { get; set; }
        public string fFamilyCard { get; set; }
        public string fTranscripts { get; set; }
        public string fDiploma { get; set; }
        public string fCertificate { get; set; }

        public Applicant Applicant { get; set; }
    }
}
