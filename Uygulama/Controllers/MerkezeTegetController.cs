using EgitimPortali.DTO;
using EgitimPortali.Request.SorularinCevaplari;
using EgitimPortali.Request.Yorumlar;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Uygulama.Controllers
{
    public class MerkezeTegetController : Controller
    {
        public IActionResult Anasayfa()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Iletisim()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Iletisim(IletisimDto p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/Iletisim", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return View();
            }
            return View(p);
        }
        public async Task<IActionResult> Ders(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/DersIcerikleri/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<DersIcerikleriDto>(jsonEmployee);     
                ViewBag.id = id;      
                ViewBag.konuid = values.KonularID;
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> YorumYap(YorumlarPostRequest p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/Yorumlar", content);
            if (responseMessage.IsSuccessStatusCode)
            { 
                return View();
            }
            return View(p);
        }
        [HttpPost]
        public async Task<IActionResult> Add(YorumlarPostRequest commentAddDto)
        {
            int sayi = commentAddDto.DersIcerikleriID;
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(commentAddDto);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/Yorumlar", content);
            if (responseMessage.IsSuccessStatusCode)
            {          
                return RedirectToAction("Ders", new { id = sayi });
            }
            return View(commentAddDto);
        }
        
     
        public async Task<IActionResult> Son3Ders(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/DersIcerikleri/son3ders/" + id);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<DersIcerikleriDto>>(jsonString);
            return View(values);
        }
        public async Task<IActionResult> YorumlariListele(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Yorumlar/yorumlar/" + id);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }
        public class Class1
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        [HttpGet]
        public async Task<IActionResult> Konular(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Konular/konular/" + id);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<KonularDto>>(jsonString);

            var responseMessage2 = await httpClient.GetAsync("https://localhost:7179/api/Dersler/dersler/" + id);
            var jsonString2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.kategori = jsonString2;
            var responseMessage3 = await httpClient.GetAsync("https://localhost:7179/api/Dersler/" + id);
            var jsonString3 = await responseMessage3.Content.ReadAsStringAsync();
            Class1 m = JsonConvert.DeserializeObject<Class1>(jsonString3);
            ViewBag.id = id;
            ViewBag.dersicerigi = m.Name;
            return View(values);
        }

        public async Task<IActionResult> DersIcerikleri(int id)
        {   
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/DersIcerikleri/konular/" + id);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<DersIcerikleriDto>>(jsonString);

            return View(values);
        }
        public async Task<IActionResult> SoruCevap(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Sorular/dersleregore/" + id);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<SorularDto>>(jsonString);
            return View(values);
        }

        public async Task<IActionResult> SoruDetay(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Sorular/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<SorularDto>(jsonEmployee);
                ViewBag.id = id;
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CevapYaz(SorularinCevaplariPostRequest p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/SorularinCevaplari", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return View();
            }
            return View(p);
        }
        [HttpPost]
        public async Task<IActionResult> CevapEkle(SorularinCevaplariPostRequest commentAddDto)
        {
            int sayi = commentAddDto.SorularID;
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(commentAddDto);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/SorularinCevaplari", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SoruDetay", new { id = sayi });
            }
            return View(commentAddDto);
        }
    }
}