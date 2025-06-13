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

        public ProductsController(ICategoryService categoryService, IProductService service)
        {
            _categoryService = categoryService;
            _service = service;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var products = await _service.GetAll(cancellationToken);
            ViewBag.Confirm = TempData["Confirm"];
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
        public async Task<IActionResult> Create(Product product, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var newEntity = await _service.Add(product, cancellationToken);
                return RedirectToAction("Index", "Photos", new { id = newEntity.Id });
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
                    TempData["Confirm"] = "<script>$(document).ready(function () {MostraConfirm('Sucesso', 'Editado com sucesso!');})</script>";
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
            TempData["Confirm"] = "<script>$(document).ready(function () {MostraConfirm('Sucesso', 'Deletado com sucesso!');})</script>";
            return RedirectToAction(nameof(Index));
        }
    }
}
