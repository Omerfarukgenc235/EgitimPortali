using EgitimPortali.DTO;
using EgitimPortali.Models;
using EgitimPortali.Request.Authenticate;
using EgitimPortali.Request.Kullanicilar;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Net.Http;
using System.Text;

namespace Uygulama.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GirisYap(AuthenticateRequest p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/Auth/login", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true
                };
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                Response.Cookies.Append("tokenim", jsonString, cookieOptions);

                return RedirectToAction("AnaSayfa", "MerkezeTeget");
            }
            return View(p);
        }
        [HttpGet]
        public IActionResult KayitOl()
        {
            ViewBag.v = Request.Cookies["tokenim"];

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> KayitOl(KullanicilarPostRequest p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/Auth/register", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GirisYap");
            }
            return View(p);
        }
    }
}
