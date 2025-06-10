using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Entities;

namespace Ventra.Infrastructure.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<IEnumerable<Photo>> GetAll(Guid id, CancellationToken cancellationToken);
        Task Add(Guid id, List<IFormFile> files, string folderPath, CancellationToken cancellationToken);
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
