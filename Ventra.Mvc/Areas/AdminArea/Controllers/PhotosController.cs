using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ventra.Domain.Entities;
using Ventra.Infrastructure.Context;
using Ventra.Infrastructure.CrossCutting.Interfaces;
using Ventra.Infrastructure.Services.Interfaces;

namespace Ventra.Mvc.Areas.AdminArea.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IPhotoService _service;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly string _folderPath;

        public PhotosController(IPhotoService service, IConfiguration configuration, IWebHostEnvironment env)
        {
            _service = service;
            _configuration = configuration;
            _env = env;
            _folderPath = Path.Combine(env.WebRootPath, _configuration.GetValue<string>("ProductsFolderUpload") ?? throw new ArgumentNullException("ProductsFolderUpload configuration is missing."));
        }

        public IActionResult Index(Guid? id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        public async Task<IActionResult> GetAll(Guid id)
        {
            var cancellationToken = HttpContext.RequestAborted;
            var photos = await _service.GetAll(id, cancellationToken);

            var response = photos.Select(photo => new
            {
                photo.Id,
                photo.Name,
                ProductId = photo.ProductId ?? Guid.Empty,
            });

            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid id, List<IFormFile> file, CancellationToken cancellationToken)
        {
            await _service.Add(id, file, _folderPath, cancellationToken);
            return RedirectToAction(nameof(Index), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id, CancellationToken.None);
            return Json(new { success = true });
        }
    }
}
