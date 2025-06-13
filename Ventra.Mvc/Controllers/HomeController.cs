using Microsoft.AspNetCore.Mvc;

namespace Ventra.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Confirm = TempData["Confirm"];
            return View();
        }
    }
}
