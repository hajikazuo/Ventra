using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Entities;

namespace Ventra.Infrastructure.CrossCutting.Interfaces
{
    public interface IUploadService
    {
        Task<Photo> UploadPhoto(string folderPath, Guid productId, IFormFile file, CancellationToken cancellationToken);
        Task<Banner> UploadBanner(string folderPath, IFormFile file, CancellationToken cancellationToken);
    }
}
