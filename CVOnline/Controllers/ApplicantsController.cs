using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVOnline.Models;
using CVOnline.Repositories.Data;
using CVOnline.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CVOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly BiodataRepository _biodataRepository;
        private readonly EducationalDetailsRepository _educationalDetailsRepository;
        private readonly DocumentRepository _documentRepository;
        private readonly WorkExperienceRepository _workExperienceRepository;
        private readonly ApplicantRepository _applicantRepository;
        public IConfiguration _configuration;

        DynamicParameters parameters = new DynamicParameters();


        public ApplicantsController(
            BiodataRepository biodataRepository,
            EducationalDetailsRepository educationalDetailsRepository,
            DocumentRepository documentRepository,
            WorkExperienceRepository workExperienceRepository,
            ApplicantRepository applicantRepository,
            IConfiguration configuration
            )
        {
            this._biodataRepository = biodataRepository;
            this._educationalDetailsRepository = educationalDetailsRepository;
            this._documentRepository = documentRepository;
            this._workExperienceRepository = workExperienceRepository;
            this._applicantRepository = applicantRepository;
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("RegisterApplicant")]
        public async Task<ActionResult> Register([FromBody] ApplicantVM model) 
        {
            Biodata biodata = new Biodata();
            biodata.IdCard = model.IdCard;
            biodata.FirstName = model.FirstName;
            biodata.LastName = model.LastName;
            biodata.PlaceOfDate = model.PlaceOfDate;
            biodata.BirthDate = model.BirthDate;
            biodata.Religion = model.Religion;
            biodata.Gender = model.Gender;
            biodata.PhoneNumber = model.PhoneNumber;
            biodata.Address = model.Address;
            biodata.MaritalStatus = model.MaritalStatus;
            var result1 = await _biodataRepository.PostAsync(biodata);

            EducationalDetails education = new EducationalDetails();
            education.Level = model.Level;
            education.Name = model.Name;
            education.Majors = model.Majors;
            education.YearOfEntry = model.YearOfEntry;
            education.GraduationYear = model.GraduationYear;
            education.Place = model.Place;
            education.FinalValue = model.FinalValue;
            var result2 = await _educationalDetailsRepository.PostAsync(education);

            WorkExperience workexp = new WorkExperience();
            workexp.CompanyName = model.CompanyName;
            workexp.LastPosition = model.LastPosition;
            workexp.TypeOfBussiness = model.TypeOfBussiness;
            workexp.YearStartedWorking = model.YearStartedWorking;
            workexp.YearOfResign = model.YearOfResign;
            workexp.LastSalary = model.LastSalary;
            var result3 = await _workExperienceRepository.PostAsync(workexp);

            Document document = new Document();
            document.fIdCard = model.fIdCard;
            document.fResume = model.fCV;
            document.fCV = model.fCV;
            document.fFamilyCard = model.fFamilyCard;
            document.fTranscripts = model.fTranscripts;
            document.fDiploma = model.fDiploma;
            document.fCertificate = model.fCertificate;
            var result4 = await _documentRepository.PostAsync(document);

            if (result1 != null && result2 != null && result3 != null && result4 != null)
            {
                Applicant applicant = new Applicant();
                applicant.Biodata_Id = biodata.Id;
                applicant.EducationalDetails_Id = education.Id;
                applicant.Document_Id = document.Id;
                applicant.WorkExperience_Id = workexp.Id;
                applicant.User_Id = model.User_Id;
                await _applicantRepository.PostAsync(applicant);

                return Ok("Registered Applicant Success!");
            }
            else 
            {
                return BadRequest("Failed to register!");
            }

        }

        
        // Get All Applicant
        [HttpGet]
        public async Task<IEnumerable<ApplicantVM>> Get() 
        {
            return await _applicantRepository.Get();
        }


        // Applicant Details
        [HttpGet("{id}")]
        public async Task<IEnumerable<ApplicantVM>> Get(int Id)
        {
            return await _applicantRepository.GetById(Id);
        }

        // Delete Applicant
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Applicant>> Delete(int Id)
        //{
        //    return await _applicantRepository.DeleteAsync(Id);
        //}

        // Edit Applicant





    }
}