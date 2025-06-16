using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Ventra.Domain.Dto;
using Ventra.Infrastructure.Services.Interfaces;

namespace Ventra.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _service;

        public HomeController(ICategoryService categoryService, IProductService service): base(categoryService)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var products = await _service.GetAll(new ProductFilterDto { OnlyFeatured = true }, cancellationToken);
            ViewBag.Confirm = TempData["Confirm"];
            return View(products);
        }
    }
}
