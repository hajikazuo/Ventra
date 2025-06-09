using Microsoft.AspNetCore.Mvc;

namespace Ventra.Mvc.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
