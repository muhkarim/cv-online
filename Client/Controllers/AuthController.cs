using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

namespace Client.Controllers
{
    public class AuthController : Controller
    {
        private HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44348/api/")
        };


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel loginVM)
        {

            var myContent = JsonConvert.SerializeObject(loginVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = client.PostAsync("Users/Login/", byteContent).Result;

            if (result.IsSuccessStatusCode)
            {
                var data = result.Content.ReadAsStringAsync().Result;
                var handler = new JwtSecurityTokenHandler();
                var datajson = handler.ReadJwtToken(data);

                // get token
                string token = "Bearer " + data;
                string role = datajson.Claims.First(claim => claim.Type == "RoleName").Value;
                string email = datajson.Claims.First(claim => claim.Type == "Email").Value;
                string user_id = datajson.Claims.First(claim => claim.Type == "User_Id").Value;

                //set token
                HttpContext.Session.SetString("JWTToken", token);
                HttpContext.Session.SetString("Role", role);
                HttpContext.Session.SetString("Email", email);
                HttpContext.Session.SetString("User_Id", user_id);

                if (role == "Admin")
                {
                    return RedirectToAction("Index", "Jobs");
                }
                else
                {
                    return RedirectToAction("Index", "UserApplicants"); // homepage user
                }

            }
            else
            {

                return View();
            }


        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            var myContent = JsonConvert.SerializeObject(model);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = client.PostAsync("Users/Register", byteContent).Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Auth");
            }
            else {
                return View();
            }


        }


        [HttpGet]
        public IActionResult ForgotPassword() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(UserVM userVM )
        {
            var newPass = Guid.NewGuid().ToString(); 
            userVM.Password = newPass;

            var myContent = JsonConvert.SerializeObject(userVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            var result = client.PutAsync("Users/ForgotPassword", byteContent).Result;

            if (result.IsSuccessStatusCode)
            {
                SendPasswordEmail(userVM, "Pasword Recovery");
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }


        public void SendPasswordEmail(UserVM userVM, string message)
        {
            var from = "keepkarim@gmail.com";
            var to = userVM.Email;
            MailMessage mm = new MailMessage(from, to);
            string today = DateTime.Now.ToString();
            mm.Subject = message + " (" + today + ")";
            mm.Body = string.Format("Hi {0},<br /><br />Your password is: <br />{1}<br /><br />", userVM.Email, userVM.Password);
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


        public IActionResult Logout()
        {
            // clear session
            HttpContext.Session.Remove("JWTToken");
            HttpContext.Session.Remove("Email");
            HttpContext.Session.Remove("Role");
            HttpContext.Session.Remove("User_Id");

            return RedirectToAction("Login", "Auth"); // back to login

        }


        public IActionResult NotFoundPage()
        {

            return View();
        }

    }
}