using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Entities;

namespace Ventra.Infrastructure.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken);
        Task<Category> GetById(Guid id, CancellationToken cancellationToken);
        Task<Category> Add(Category category, CancellationToken cancellationToken);
        Task<Category> Update(Category category, CancellationToken cancellationToken);
        Task<Category> Delete(Guid id, CancellationToken cancellationToken);
    }
}
