using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Ventra.Domain.Dto;
using Ventra.Infrastructure.Services.Interfaces;

namespace Ventra.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _service;

        public HomeController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var filter = new ProductFilterDto
            {
                OnlyFeatured = true
            };
            var products = await _service.GetAll(filter, cancellationToken);
            ViewBag.Confirm = TempData["Confirm"];
            return View(products);
        }
    }
}
