using EgitimPortali.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Uygulama.Controllers
{
    public class OgretmenController : Controller
    {
        public async Task<IActionResult> Konular(int id)
        {       
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Konular/konular/" + id);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<KonularDto>>(jsonString);
            return View(values);
        }
        [HttpGet]
        public IActionResult KonuEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KonuEkle(int id)
        {
            return View();
        }
        public IActionResult DersIcerikleri(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult YeniDersIcerigiEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniDersIcerigiEkle(int id)
        {
            return View();
        }
    }
}
