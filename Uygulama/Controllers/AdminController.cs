using Microsoft.AspNetCore.Mvc;

namespace Uygulama.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
