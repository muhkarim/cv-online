using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVOnline.ViewModels
{
    public class ApplicantVM
    {
        public int Id { get; set; }
        public int Document_Id { get; set; }
        public int EducationalDetail_Id { get; set; }
        public int Biodata_Id { get; set; }
        public int User_Id { get; set; }
        public int WorkExperience_Id { get; set; }

        public string fIdCard { get; set; } 
        public string fResume { get; set; }
        public string fCV { get; set; }
        public string fFamilyCard { get; set; }
        public string fTranscripts { get; set; }
        public string fDiploma { get; set; }
        public string fCertificate { get; set; }

        public string IdCard { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlaceOfDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string Religion { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string MaritalStatus { get; set; }

        public string Level { get; set; }
        public string Name { get; set; }
        public string Majors { get; set; }
        public string YearOfEntry { get; set; }
        public string GraduationYear { get; set; }
        public string Place { get; set; }
        public string FinalValue { get; set; }

        public string CompanyName { get; set; }
        public string LastPosition { get; set; }
        public string TypeOfBussiness { get; set; }
        public string YearStartedWorking { get; set; }
        public string YearOfResign { get; set; }
        public string LastSalary { get; set; }

    }

    
}
