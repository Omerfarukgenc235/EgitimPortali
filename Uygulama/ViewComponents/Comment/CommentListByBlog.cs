﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Uygulama.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
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
    }
}
