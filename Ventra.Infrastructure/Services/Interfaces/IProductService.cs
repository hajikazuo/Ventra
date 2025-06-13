using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Dto;
using Ventra.Domain.Entities;

namespace Ventra.Infrastructure.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll(ProductFilterDto? filter, CancellationToken cancellationToken);
        Task<Product> GetById(Guid id, CancellationToken cancellationToken);
        Task<Product> Add(Product product, CancellationToken cancellationToken);
        Task<Product> Update(Product product, CancellationToken cancellationToken);
        Task<Product> Delete(Guid id, CancellationToken cancellationToken);
    }
}
