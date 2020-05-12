using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CVOnline.Models;
using CVOnline.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class UsersController : Controller
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
                return View(LoadUsers());
            }

            return RedirectToAction("NotFoundPage", "Auth");


        }

        public JsonResult LoadUsers()
        {
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

            IEnumerable<User> user = null;
           
            var responseTask = client.GetAsync("Users"); 
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<User>>(); 
                readTask.Wait();
                user = readTask.Result;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(user);
        }

        public JsonResult InsertOrUpdate(User user)
        {
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

            var myContent = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (user.Id == 0)
            {
                var result = client.PostAsync("Users/Register", byteContent).Result;
                return Json(result);
            }
            else
            {
                var result = client.PutAsync("Users/" + user.Id, byteContent).Result;
                return Json(result);
            }
        }

        public JsonResult GetById(int Id)
        {
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

            UserVM userVM = null;
            var responseTask = client.GetAsync("Users/" + Id); 
            responseTask.Wait(); 
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode) 
            {
                var readTask = result.Content.ReadAsAsync<IList<UserVM>>(); 
                readTask.Wait();
                userVM = readTask.Result[0];
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(userVM);
        }

        public JsonResult Delete(int Id)
        {
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWTToken"));

            var result = client.DeleteAsync("Users/" + Id).Result;
            return Json(result);
        }



    }
}