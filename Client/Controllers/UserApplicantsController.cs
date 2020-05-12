using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CVOnline.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class UserApplicantsController : Controller
    {

        private HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44348/api/")
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyProfile()
        {
            return View();
        }
        public IActionResult InputProfile()
        {
            return View();
        }

        public IActionResult WizardApplicant()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Insert(ApplicantVM model)
        {
            var userID = Int32.Parse(HttpContext.Session.GetString("User_Id"));
            model.User_Id = userID;

            var myContent = JsonConvert.SerializeObject(model);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = client.PostAsync("Applicants/RegisterApplicant", byteContent).Result;
            
            return Json(result);


        }

        public JsonResult LoadProfile()
        {

            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));
            
            var user_id = Int32.Parse(HttpContext.Session.GetString("User_Id"));

            //ApplicantVM applicantVM = null;
            //var responseTask = client.GetAsync("applicants/" + user_id);
            //responseTask.Wait();
            //var result = responseTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<IList<ApplicantVM>>();
            //    readTask.Wait();
            //    return Json(readTask.Result[0]);

            //}
            //else
            //{
            //    return Json(result);
            //}

            ApplicantVM applicant = null;
            var responseTask = client.GetAsync("applicants/" + user_id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ApplicantVM>>();
                readTask.Wait();
                applicant = readTask.Result[0];
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(applicant);
        }


        public JsonResult Update(ApplicantVM model)
        {
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

            var myContent = JsonConvert.SerializeObject(model);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = client.PutAsync("Applicants/" + model.Id, byteContent).Result;
            return Json(result);

        }



    }
}