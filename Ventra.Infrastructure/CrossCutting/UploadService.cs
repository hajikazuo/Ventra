using Microsoft.AspNetCore.Http;
using RT.Comb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Entities;
using Ventra.Domain.Interfaces;
using Ventra.Infrastructure.Context;
using Ventra.Infrastructure.CrossCutting.Interfaces;

namespace Ventra.Infrastructure.CrossCutting
{
    public class UploadService : IUploadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICombProvider _comb;

        public UploadService(IUnitOfWork unitOfWork, ICombProvider comb)
        {
            _unitOfWork = unitOfWork;
            _comb = comb;
        }

        public async Task<Photo> UploadPhoto(string folderPath, Guid productId, IFormFile file, CancellationToken cancellationToken)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File cannot be null or empty.", nameof(file));
            }

            string extension = ValidateExtension(file);

            var fileName = $"{productId}_{Guid.NewGuid()}{extension}";
            var fullPath = System.IO.Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new Photo
            {
                Id = _comb.Create(),
                Name = fileName,
                ProductId = productId
            };

            return photo;
        }

        private static string ValidateExtension(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(extension))
                throw new InvalidOperationException("File type not allowed.");
            return extension;
        }
    }
}
