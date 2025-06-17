using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ventra.Domain.Entities;
using Ventra.Infrastructure.Services.Interfaces;

namespace Ventra.Mvc.Areas.AdminArea.Controllers
{
    public class BannersController : Controller
    {
        private readonly IBannerService _service;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly string _folderPath;

        public BannersController(IBannerService service, IConfiguration configuration, IWebHostEnvironment env)
        {
            _service = service;
            _configuration = configuration;
            _env = env;
            _folderPath = Path.Combine(env.WebRootPath, _configuration.GetValue<string>("BannersFolderUpload") ?? throw new ArgumentNullException("BannersFolderUpload configuration is missing."));
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var banners = await _service.GetAll(cancellationToken);
            ViewBag.Confirm = TempData["Confirm"];
            return View(banners);
        }

        public async Task<IActionResult> Details(Guid? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _service.GetById(id.Value, cancellationToken);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<IFormFile> file, CancellationToken cancellationToken)
        {
            await _service.Add(file, _folderPath, cancellationToken);
            TempData["Confirm"] = "<script>$(document).ready(function () {MostraConfirm('Sucesso', 'Cadastrado com sucesso!');})</script>";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banner = await _service.GetById(id.Value, cancellationToken);

            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Banner banner, CancellationToken cancellationToken)
        {
            if (id != banner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(banner, cancellationToken);
                    TempData["Confirm"] = "<script>$(document).ready(function () {MostraConfirm('Sucesso', 'Editado com sucesso!');})</script>";
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(banner);
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
