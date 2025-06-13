using Microsoft.AspNetCore.Mvc;
using Ventra.Infrastructure.Services.Interfaces;

namespace Ventra.Mvc.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Details(Guid? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _service.GetById(id.Value, cancellationToken);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
