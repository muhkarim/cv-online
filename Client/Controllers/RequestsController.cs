using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using CVOnline.Models;
using CVOnline.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Ocsp;

namespace Client.Controllers
{
    public class RequestsController : Controller
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
                return View(LoadRequest());
            }

            return RedirectToAction("NotFoundPage", "Auth");
        }


        public JsonResult LoadRequest()
        {
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

            IEnumerable<RequestAllVM> request = null;
            
            var responseTask = client.GetAsync("Requests"); 
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode) 
            {
                var readTask = result.Content.ReadAsAsync<IList<RequestAllVM>>(); 
                readTask.Wait();
                request = readTask.Result;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(request);
        }


        public JsonResult ApproveJobs(RequestVM requestVM, int id)
        {
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

            var myContent = JsonConvert.SerializeObject(requestVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PutAsync("Requests/ApprovalJobs/" + id, byteContent).Result;
            
            if (result.IsSuccessStatusCode)
            {
                SendEmailApprove(requestVM, "Status Application - CV Online");
               
            }
            return Json(result);
        }

        public JsonResult DeclineJobs(RequestVM requestVM, int id)
        {
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

            var myContent = JsonConvert.SerializeObject(requestVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = client.PutAsync("Requests/DeclineJobs/" + id, byteContent).Result;

            if (result.IsSuccessStatusCode)
            {
                SendEmailDecline(requestVM, "Status Application - CV Online");
            }

            return Json(result);

        }

        public JsonResult ApplyJobClient(Request model)
        {
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

            var applicantID = Int32.Parse(HttpContext.Session.GetString("User_Id"));
            model.Applicants_Id = applicantID;

            var myContent = JsonConvert.SerializeObject(model);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            
            var result = client.PostAsync("Requests", byteContent).Result; 
            return Json(result);
            
        }

        public JsonResult GetById(int Id)
        {
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

            RequestVM requestVM = null;
            var responseTask = client.GetAsync("Requests/" + Id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<RequestVM>>();
                readTask.Wait();
                requestVM = readTask.Result[0];
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(requestVM);
        }

        public void SendEmailApprove(RequestVM requestVM, string message)
        {
            var from = "keepkarim@gmail.com";
            var to = requestVM.Email;
            //var name = requestVM.FirstName;
            MailMessage mm = new MailMessage(from, to);
            string today = DateTime.Now.ToString();
            mm.Subject = message + " (" + today + ")";
            mm.Body = string.Format("Hi {0},<br /><br />Your Application Has Been Approve", requestVM.FirstName);
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;


            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = "keepkarim@gmail.com";
            NetworkCred.Password = "karimgmail9";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }

        public void SendEmailDecline(RequestVM requestVM, string message)
        {
            var from = "keepkarim@gmail.com";
            var to = requestVM.Email;
            //var name = requestVM.FirstName;
            MailMessage mm = new MailMessage(from, to);
            string today = DateTime.Now.ToString();
            mm.Subject = message + " (" + today + ")";
            mm.Body = string.Format("Hi {0},<br /><br />Sorry, Your Application Has Been Decline", requestVM.FirstName);
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;


            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = "keepkarim@gmail.com";
            NetworkCred.Password = "karimgmail9";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }

    }
}