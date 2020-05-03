using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CVOnline.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class JobsController : Controller
    {

        private HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44348/api/")
        };

        public IActionResult Index()
        {
            return View(LoadJobs());
        }


        public JsonResult LoadJobs()
        {
            IEnumerable<Job> jobs = null;
            var responseTask = client.GetAsync("Jobs");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode) 
            {
                var readTask = result.Content.ReadAsAsync<IList<Job>>(); 
                readTask.Wait();
                jobs = readTask.Result;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(jobs);
        }
    }
}