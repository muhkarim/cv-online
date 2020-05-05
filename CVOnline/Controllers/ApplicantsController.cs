using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVOnline.Bases;
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
            document.fResume = model.fResume;
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
        // api/applcants/getall
        [HttpGet]
        public async Task<IEnumerable<ApplicantVM>> Get()
        {
            return await _applicantRepository.Get();
        }


        // Applicant Details
        [HttpGet("{id}")]
        public async Task<IEnumerable<ApplicantVM>> GetById(int Id)
        {
            return await _applicantRepository.GetById(Id);
        }



        // Edit Applicant
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit (int Id, ApplicantVM model)
        {
            // update biodata
            var updateBiodata = await _biodataRepository.GetAsync(Id);
            updateBiodata.IdCard = model.IdCard;
            updateBiodata.FirstName = model.FirstName;
            updateBiodata.LastName = model.LastName;
            updateBiodata.PlaceOfDate = model.PlaceOfDate;
            updateBiodata.BirthDate = model.BirthDate;
            updateBiodata.Religion = model.Religion;
            updateBiodata.Gender = model.Gender;
            updateBiodata.PhoneNumber = model.PhoneNumber;
            updateBiodata.Address = model.Address;
            updateBiodata.MaritalStatus = model.MaritalStatus;
            var result1 = await _biodataRepository.PutAsync(updateBiodata);

            // update education
            var updateEducation = await _educationalDetailsRepository.GetAsync(Id);
            updateEducation.Level = model.Level;
            updateEducation.Name = model.Name;
            updateEducation.Majors = model.Majors;
            updateEducation.YearOfEntry = model.YearOfEntry;
            updateEducation.GraduationYear = model.GraduationYear;
            updateEducation.Place = model.Place;
            updateEducation.FinalValue = model.FinalValue;
            var result2 = await _educationalDetailsRepository.PutAsync(updateEducation);


            // upadate work
            var updateWorkEx = await _workExperienceRepository.GetAsync(Id);
            updateWorkEx.CompanyName = model.CompanyName;
            updateWorkEx.LastPosition = model.LastPosition;
            updateWorkEx.TypeOfBussiness = model.TypeOfBussiness;
            updateWorkEx.YearStartedWorking = model.YearStartedWorking;
            updateWorkEx.YearOfResign = model.YearOfResign;
            updateWorkEx.LastSalary = model.LastSalary;
            var result3 = await _workExperienceRepository.PutAsync(updateWorkEx);


            // update document
            var updateDocument = await _documentRepository.GetAsync(Id);
            updateDocument.fIdCard = model.fIdCard;
            updateDocument.fResume = model.fResume;
            updateDocument.fCV = model.fCV;
            updateDocument.fFamilyCard = model.fFamilyCard;
            updateDocument.fTranscripts = model.fTranscripts;
            updateDocument.fDiploma = model.fDiploma;
            updateDocument.fCertificate = model.fCertificate;
            var result4 = await _documentRepository.PutAsync(updateDocument);



            if (result1 != null && result2 != null && result3 != null && result4 != null)
            {
                return Ok("Update Successfully!");
            }
            else {
                return BadRequest("Failed to update applicant!");
            }



        }


        // Delete Applicant
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Applicant>> Delete(int Id)
        {
            var delete = await _applicantRepository.DeleteAsync(Id);
            if (delete == null)
            {
                return NotFound();
            }
            return delete;
        }






    }
}