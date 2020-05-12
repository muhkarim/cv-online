using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVOnline.Bases;
using CVOnline.Models;
using CVOnline.Repositories.Data;
using CVOnline.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestApplicationsController : BasesController<RequestApplication, RequestApplicationRepository>
    {
        private readonly RequestApplicationRepository _requestApplicationRepository;
        public RequestApplicationsController(RequestApplicationRepository requestApplicationRepository) : base(requestApplicationRepository)
        {
            this._requestApplicationRepository = requestApplicationRepository;
        }




        [HttpPost]
        [Route("ApplyJob")]
        public async Task<ActionResult> ApplyJob(RequestApplicationVM model)
        {
            RequestApplication request = new RequestApplication();
            request.CreateDate = model.CreateDate;
            request.Status = model.Status;
            request.Jobs_Id = model.Job_Id;

            var result = await _requestApplicationRepository.PostAsync(request);

            if(result != null)
            {
                await _requestApplicationRepository.InsertUserRequest(model.Applicants_Id, request.Id);

                return Ok("Apply Job Successfully!");
            }

            return BadRequest("Failed to apply jobs");


        }



    }
}