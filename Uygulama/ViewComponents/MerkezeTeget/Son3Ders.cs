using EgitimPortali.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Uygulama.ViewComponents.MerkezeTeget
{
    public class Son3Ders : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7179/api/DersIcerikleri/son3ders/" + id);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<DersIcerikleriDto>>(jsonString);
            return View(values);
        }
    }
}
