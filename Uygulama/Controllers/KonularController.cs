using EgitimPortali.DTO;
using EgitimPortali.Request.Konular;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Uygulama.Controllers
{
    public class KonularController : Controller
    {
        public async Task<IActionResult> ButunKonular()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Konular");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<KonularDto>>(jsonString);
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> YeniKonuEkle()
        {
            var httpClient = new HttpClient();
            var responseMessage2 = await httpClient.GetAsync("https://localhost:7179/api/Dersler");
            var jsonString = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<DerslerDto>>(jsonString);
            List<SelectListItem> categoryvalue = (from x in values2
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()

                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> YeniKonuEkle(KonularPostRequest p)
        {
            var httpClient = new HttpClient();
            var responseMessage2 = await httpClient.GetAsync("https://localhost:7179/api/Dersler");
            var jsonString = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<DerslerDto>>(jsonString);
            List<SelectListItem> categoryvalue = (from x in values2
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()

                                                  }).ToList();
            ViewBag.cv = categoryvalue;

            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/Konular", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ButunKonular");
            }
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> KonuGuncelle(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage2 = await httpClient.GetAsync("https://localhost:7179/api/Dersler");
            var jsonString = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<DerslerDto>>(jsonString);
            List<SelectListItem> categoryvalue = (from x in values2
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()

                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Konular/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<KonularUpdateRequest>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("ButunKonular");
        }
        [HttpPost]
        public async Task<IActionResult> KonuGuncelle(KonularUpdateRequest p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7179/api/Konular/" + p.Id, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ButunKonular");
            }
            return View(p);
        }
        public async Task<IActionResult> KonuSil(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:7179/api/Konular/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ButunKonular");
            }
            return View();
        }
    }
}
