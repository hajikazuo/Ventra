using Microsoft.AspNetCore.Mvc;
using Ventra.Domain.Dto;
using Ventra.Infrastructure.Services.Interfaces;

namespace Ventra.Mvc.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(ICategoryService categoryService, IProductService service) : base(categoryService)
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

        public async Task<IActionResult> Search([FromQuery]string search, CancellationToken cancellationToken)
        {
            var products = await _service.GetAll(new ProductFilterDto { Search = search }, cancellationToken);
            return View(products);
        }

        public async Task<IActionResult> SearchByCategories(Guid id, CancellationToken cancellationToken)
        {
            var products = await _service.GetAll(new ProductFilterDto { CategoryId = id }, cancellationToken);
            return View("Search", products);
        }
    }
}
