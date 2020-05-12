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
    public class RequestsController : ControllerBase
    {
        private readonly RequestRepository _requestRepository;

        public IConfiguration _configuration;

        DynamicParameters parameters = new DynamicParameters();


        public RequestsController(RequestRepository requestRepository, IConfiguration configuration)
        {
            this._requestRepository = requestRepository;
            this._configuration = configuration;
        }


        [HttpGet]
        public async Task<IEnumerable<RequestAllVM>> Get()
        {
            return await _requestRepository.GetAllRequest();
        }

        [HttpGet("{RequestId}")]
        public async Task<IEnumerable<RequestVM>> Get(int RequestId)
        {
            return await _requestRepository.GetAllRequestById(RequestId);
        }

        // request user applicant jobs
        [HttpPost]
        public async Task<ActionResult<Request>> ApplyJob(Request model) 
        {
            Request request = new Request();
            request.Applicants_Id = model.Applicants_Id;
            request.Jobs_Id = model.Jobs_Id;
            request.Status = "Waiting";
            request.CreateDate = DateTime.Now;
            return await _requestRepository.PostAsync(request);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, Request model)
        {
            
                var request = await _requestRepository.GetAsync(id);

                

                return Ok("Success updated password!");
            

            return BadRequest("Failed to update password!");

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> Delete(int id)
        {
            return await _requestRepository.DeleteAsync(id);
        }

        [HttpPut("ApprovalJobs/{id}")]
        public async Task<ActionResult<Request>> ApprovalJobs(int id, Request model)
        {
            var put = await _requestRepository.GetAsync(id);
            if (put == null)
            {
                return NotFound();
            }
            put.Status = "Approved";

            await _requestRepository.PutAsync(put);
            return Ok("Successfully Approve Request Data");



        }

        [HttpPut("DeclineJobs/{id}")]
        public async Task<ActionResult<Request>> DeclineJobs(int id, Request model)
        {
            var put = await _requestRepository.GetAsync(id);
            if (put == null)
            {
                return NotFound();
            }
            put.Status = "Decline";

            await _requestRepository.PutAsync(put);
            return Ok("Successfully Decline Request Data");
        }
    }
}