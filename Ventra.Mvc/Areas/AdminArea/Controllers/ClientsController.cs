using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ventra.Domain.Entities;
using Ventra.Domain.Enums;
using Ventra.Infrastructure.Context;
using Ventra.Infrastructure.Extensions;
using Ventra.Infrastructure.Services.Interfaces;

namespace Ventra.Mvc.Areas.AdminArea.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var clients = await _service.GetAll(cancellationToken);
            return View(clients);
        }

        public async Task<IActionResult> Details(Guid? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _service.GetById(id.Value, cancellationToken);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        public IActionResult Create()
        {
            ViewData["UserStatus"] = this.AssembleSelectListToEnum(new UserStatus());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Client client, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(client, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserStatus"] = this.AssembleSelectListToEnum(new UserStatus());
            return View(client);
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
            ViewData["UserStatus"] = this.AssembleSelectListToEnum(new UserStatus());
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Client client, CancellationToken cancellationToken)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(client, cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["UserStatus"] = this.AssembleSelectListToEnum(new UserStatus());
            return View(client);
        }

        public async Task<IActionResult> Delete(Guid? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _service.GetById(id.Value, cancellationToken);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
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
