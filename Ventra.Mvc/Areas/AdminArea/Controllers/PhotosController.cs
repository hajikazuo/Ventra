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
    [Area("AdminArea")]
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
            _folderPath = Path.Combine(env.WebRootPath, _configuration.GetValue<string>("FolderUpload") ?? throw new ArgumentNullException("FolderUpload configuration is missing."));
        }

        public async Task<IActionResult> Index(Guid? id, CancellationToken cancellationToken)
        {
            var photos = await _service.GetAll(id.Value, cancellationToken);
            ViewBag.ProductId = id;
            return View(photos);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid id, List<IFormFile> files, CancellationToken cancellationToken)
        {
            await _service.Add(id, files, _folderPath, cancellationToken);
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
