using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ventra.Domain.Entities;
using Ventra.Infrastructure.Context;
using Ventra.Infrastructure.Services.Interfaces;

namespace Ventra.Mvc.Areas.AdminArea.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _service;
        private readonly IConfiguration _configuration;
        private readonly string _folderPath;

        public ProductsController(ICategoryService categoryService, IProductService service, IConfiguration configuration)
        {
            _categoryService = categoryService;
            _service = service;
            _configuration = configuration;

            _folderPath = _configuration["FolderUpload"] ?? throw new ArgumentNullException("FolderUpload configuration is missing.");
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var products = await _service.GetAll(cancellationToken);
            return View(products);
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

            ViewBag.Folder = _folderPath;
            return View(product);
        }

        public IActionResult Create(CancellationToken cancellationToken)
        {
            var categories = _categoryService.GetAll(cancellationToken).Result;
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, List<IFormFile> files, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(product, files, _folderPath, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            var categories = _categoryService.GetAll(cancellationToken).Result;
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        public async Task<IActionResult> Edit(Guid? id, CancellationToken cancellationToken)
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
            var categories = _categoryService.GetAll(cancellationToken).Result;
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Product product, CancellationToken cancellationToken)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(product, cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }
            var categories = _categoryService.GetAll(cancellationToken).Result;
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        public async Task<IActionResult> Delete(Guid? id, CancellationToken cancellationToken)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
}
