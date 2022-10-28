using EgitimPortali.DTO;
using EgitimPortali.Request.Dersler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Uygulama.Controllers
{
    public class DerslerController : Controller
    {
        public async Task<IActionResult> DersleriListele()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Dersler");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<DerslerDto>>(jsonString);
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> DersEkle()
        {
            var httpClient = new HttpClient();
            var responseMessage2 = await httpClient.GetAsync("https://localhost:7179/api/Kategori");
            var jsonString = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<KategoriDto>>(jsonString);
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
        public async Task<IActionResult> DersEkle(DerslerDto p)
        {
            var httpClient = new HttpClient();
            var responseMessage2 = await httpClient.GetAsync("https://localhost:7179/api/Kategori");
            var jsonString = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<KategoriDto>>(jsonString);
            List<SelectListItem> categoryvalue = (from x in values2
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()

                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/Dersler", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("DersleriListele");
            }
            return View(p);

        }
        [HttpGet]
        public async Task<IActionResult> DersGuncelle(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Dersler/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<DerslerDto>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("DersleriListele");

        }
        [HttpPost]
        public async Task<IActionResult> DersGuncelle(DerslerUpdateRequest p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7179/api/Dersler/" + p.Id, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("DersleriListele");
            }
            return View(p);
        }
        public async Task<IActionResult> DersSil(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:7179/api/Dersler/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("DersleriListele");
            }
            return View();
        }
    }
}

