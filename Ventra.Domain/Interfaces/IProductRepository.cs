using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Dto;
using Ventra.Domain.Entities;

namespace Ventra.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithIncludes(ProductFilterDto? filter, CancellationToken cancellationToken);
        Task<Product> GetByIdWithIncludes(Guid id, CancellationToken cancellationToken);
    }
}
