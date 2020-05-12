using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CVOnline.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

            var role = HttpContext.Session.GetString("Role");
            if (role == "Admin")
            {
                return View(LoadJobs());
            }

            return RedirectToAction("NotFoundPage", "Auth");
        }


        public JsonResult LoadJobs()
        {
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

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
        public JsonResult InsertOrUpdate(Job model)
        {
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

            var myContent = JsonConvert.SerializeObject(model);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (model.Id == 0)
            {
                var result = client.PostAsync("Jobs", byteContent).Result;
                return Json(result);
            }
            else
            {
                var result = client.PutAsync("Jobs/" + model.Id, byteContent).Result;
                return Json(result);
            }
        }
        public JsonResult GetById(int Id)
        {
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

            Job job = null;

            var responseTask = client.GetAsync("Jobs/" + Id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                job = JsonConvert.DeserializeObject<Job>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "server error, try after some time");
            }
            return Json(job);
        }
        public JsonResult Delete(int Id)
        {
    
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

            var result = client.DeleteAsync("Jobs/" + Id).Result;
            return Json(result);
        }


      

    }
}