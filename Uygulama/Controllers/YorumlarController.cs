using EgitimPortali.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Uygulama.Controllers
{
    public class YorumlarController : Controller
    {
        public async Task<IActionResult> ButunYorumlar()
        {       
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/Yorumlar/DerslereGoreYorumListeleme");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<YorumlarDto>>(jsonString);
            return View(values);
        }
        public async Task<IActionResult> YorumSil(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:7179/api/Yorumlar/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ButunYorumlar");
            }
            return View();
        }
    
        public IActionResult DerslereIceriklerineGoreYorumlar()
        {
            return View();
        }
    }
}
