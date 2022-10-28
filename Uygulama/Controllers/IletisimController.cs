using EgitimPortali.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Uygulama.Controllers
{
    public class IletisimController : Controller
    {
        public async Task<IActionResult> GelenIletisimMesajlari()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Iletisim");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<IletisimDto>>(jsonString);
            return View(values);
        }
        public async Task<IActionResult> IletisimMesajiSil(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:7179/api/Iletisim/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GelenIletisimMesajlari");
            }
            return View();
        }
    }
}
