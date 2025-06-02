using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ventra.Domain.Entities;
using Ventra.Infrastructure.Context;
using Ventra.Infrastructure.Services.Interfaces;

namespace Ventra.Mvc.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var categories = await _service.GetAll(cancellationToken);
            return View(categories);
        }

        public async Task<IActionResult> Details(Guid? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _service.GetById(id.Value, cancellationToken);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(category, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(Guid? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _service.GetById(id.Value, cancellationToken);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Category category, CancellationToken cancellationToken)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(category, cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(Guid? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _service.GetById(id.Value, cancellationToken);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
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
