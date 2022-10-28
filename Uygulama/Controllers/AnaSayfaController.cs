using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Uygulama.Controllers
{
    public class AnaSayfaController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Kategori");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }
        public class Class1
        {
            public string UstBaslik { get; set; }
            public string Icerik { get; set; }
        }
    }
}
