using EgitimPortali.DTO;
using EgitimPortali.Request.DersIcerikleri;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Uygulama.Controllers
{
    public class DersIcerikleriController : Controller
    {
        public async Task<IActionResult> Derslerim()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/DersIcerikleri");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<DersIcerikleriDto>>(jsonString);
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> DersGuncelle(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage2 = await httpClient.GetAsync("https://localhost:7179/api/Konular");
            var jsonString = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<KategoriDto>>(jsonString);
            List<SelectListItem> categoryvalue = (from x in values2
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()

                                                  }).ToList();
            ViewBag.cv = categoryvalue;
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/DersIcerikleri/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<DersIcerikleriDto>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("Derslerim");
        }
        [HttpPost]
        public async Task<IActionResult> DersGuncelle(DersIcerikleriDto p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7179/api/DersIcerikleri/" + p.Id, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Derslerim");
            }
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> YeniDersEkle()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Konular");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Kategoriler>>(jsonString);
            List<SelectListItem> categoryvalue = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()

                                                  }).ToList();
            ViewBag.cv = categoryvalue;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> YeniDersEkle(DersIcerikleriPostRequest p)
        {
            var httpClient = new HttpClient();
            var responseMessage2 = await httpClient.GetAsync("https://localhost:7179/api/Konular");
            var jsonString = await responseMessage2.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Kategoriler>>(jsonString);
            List<SelectListItem> categoryvalue = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()

                                                  }).ToList();
            ViewBag.cv = categoryvalue;

            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/DersIcerikleri", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Derslerim");
            }
            return View(p);
        }
        public class Kategoriler
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public async Task<IActionResult> DersSil(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:7179/api/DersIcerikleri/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Derslerim");
            }
            return View();
        }
    }
}