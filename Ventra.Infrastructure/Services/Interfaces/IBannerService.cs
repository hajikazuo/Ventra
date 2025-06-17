using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Entities;

namespace Ventra.Infrastructure.Services.Interfaces
{
    public interface IBannerService
    {
        Task<IEnumerable<Banner>> GetAll(CancellationToken cancellationToken);
        Task<Banner> GetById(Guid id, CancellationToken cancellationToken);
        Task Add(List<IFormFile> files, string folderPath, CancellationToken cancellationToken);
        Task<Banner> Update(Banner banner, CancellationToken cancellationToken);
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
