using EgitimPortali.DTO;
using EgitimPortali.Models;
using EgitimPortali.Request.DersIcerikleri;
using EgitimPortali.Request.Konular;
using EgitimPortali.Request.Test;
using EgitimPortali.Request.TestSoru;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Uygulama.Models;

namespace Uygulama.Controllers
{
    public class OgretmenController : Controller
    {
        public async Task<IActionResult> Konular(int id)
        {       
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Konular/konular/" + id);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<KonularDto>>(jsonString);
            ViewBag.cv = id;
            if (values != null)
                return View(values);
            else
                return RedirectToAction("GirisYap", "Login");
        }
        public async Task<IActionResult> KonuIcerikleri(int id)
        {        
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            ViewBag.id = id;
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/DersIcerikleri/konular/" + id);
        
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<IEnumerable<DersIcerikleriDto>>(jsonString);
        


            var responseMessage2 = await httpClient.GetAsync("https://localhost:7179/api/Test/konu/" + id);
            var jsonString2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<IEnumerable<TestDto>>(jsonString2);           
            KonuIcerikleris cs = new KonuIcerikleris();     
            cs.dersIcerikleriDtos = values;
            cs.Tests = values2;
            if (cs != null)
                return View(cs);
            else
                return RedirectToAction("GirisYap", "Login");
        }
        [HttpGet]
        public async Task<IActionResult> KonuEkle(int id)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var responseMessage2 = await httpClient.GetAsync("https://localhost:7179/api/Dersler");
            var jsonString = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<DerslerDto>>(jsonString);            
            ViewBag.cv = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KonuEkle(KonularPostRequest p)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            ViewBag.cv = p.DerslerID;
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/Konular", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Konular", new { id = p.DerslerID });
            }
            return View(p);
        }


        public async Task<IActionResult> DersinSorulari(int id)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Sorular/dersleregore/" + id);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<SorularDto>>(jsonString);
            return View(values);
        }
        public async Task<IActionResult> DerseGelenYanitlar(int id)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/SorularinCevaplari/cevaplar/" + id);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<SoruCevapDto>>(jsonString);
            return View(values);
        }
        public async Task<IActionResult> YanitKaldir(int id)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var responseMessage = await httpClient.DeleteAsync("https://localhost:7179/api/SorularinCevaplari/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("KonuIcerikleri");
            }
            return View();
        }
        public async Task<IActionResult> YorumKaldir(int id)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var responseMessage = await httpClient.DeleteAsync("https://localhost:7179/api/Yorumlar/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("KonuIcerikleri");
            }
            return View();
        }

        public async Task<IActionResult> DerseGelenYorumlar(int id)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Yorumlar/yorumlar/" + id);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<YorumlarDto>>(jsonString);
            return View(values);
        }
        public async Task<IActionResult> IcerikSil(int id)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var responseMessage = await httpClient.DeleteAsync("https://localhost:7179/api/DersIcerikleri/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("KonuIcerikleri");
            }
            return View();
        }
        public async Task<IActionResult> KonuSil(int id)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var responseMessage = await httpClient.DeleteAsync("https://localhost:7179/api/Konular/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Konular", new { id = id });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> KonuGuncelle(int id)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

    
            ViewBag.cv = id;
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Konular/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<KonularUpdateRequest>(jsonEmployee);
                if (values != null)
                    return View(values);
                else
                    return RedirectToAction("GirisYap", "Login");
            }
            return RedirectToAction("Konular");
        }
        [HttpPost]
        public async Task<IActionResult> KonuGuncelle(KonularUpdateRequest p)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7179/api/Konular/" + p.Id, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Konular", new { id = p.DerslerID });
            }
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> IcerikDuzenle(int id)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/DersIcerikleri/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<DersIcerikleriDto>(jsonEmployee);
                ViewBag.konu = values.KonularID;
                return View(values);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IcerikDuzenle(DersIcerikleriDto p)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7179/api/DersIcerikleri/" + p.Id, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("KonuIcerikleri", new { id = p.KonularID });
            }
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> YeniDersIcerigiEkle(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> YeniDersIcerigiEkle(DersIcerikleriPostRequest p)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/DersIcerikleri", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("KonuIcerikleri", new { id = p.KonularID });
            }
            return View(p);
        }
        [HttpGet]
        public IActionResult TestEkle(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TestEkle(TestPostRequest p)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/Test", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("KonuIcerikleri", new { id = p.KonularID });
            }
            return View(p);
        }
        

        public async Task<IActionResult> Test(int id)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/TestSoru/testsorulari/" + id);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<TestSoruDto>>(jsonString);
            ViewBag.id = id;
            return View(values);
        }
        [HttpGet]
        public IActionResult SoruEkle(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SoruEkle(TestSoruPostRequest p)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7179/api/TestSoru", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Test", new { id = p.TestId});
            }
            ViewBag.id = p.TestId;
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> SoruDuzenle(int id)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/TestSoru/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TestSoruDto>(jsonEmployee);
                return View(values);
            }
            return RedirectToAction("Test");
        }
        [HttpPost]
        public async Task<IActionResult> SoruDuzenle(TestSoruUpdateRequest p)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:7179/api/TestSoru/" + p.Id, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Test", new { id = p.TestId });
            }
            return View(p);
        }
        public async Task<IActionResult> TestSoruSil(int id)
        {
            var httpClient = new HttpClient();
            var Token = Request.Cookies["tokenim"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer", $"{Token}");

            var responseMessage = await httpClient.DeleteAsync("https://localhost:7179/api/TestSoru/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Test", new { id = id });
            }
            return View();
        }
    }
}