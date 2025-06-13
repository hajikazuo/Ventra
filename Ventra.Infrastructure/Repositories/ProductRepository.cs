using Microsoft.EntityFrameworkCore;
using RT.Comb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Dto;
using Ventra.Domain.Entities;
using Ventra.Domain.Interfaces;
using Ventra.Infrastructure.Context;

namespace Ventra.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(VentraDbContext context, ICombProvider comb) : base(context, comb)
        {
        }

        public async Task<IEnumerable<Product>> GetAllWithIncludes(ProductFilterDto? filter, CancellationToken cancellationToken)
        {
            filter ??= new ProductFilterDto();

            var query = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Photos)
                .AsQueryable();

            if (filter.OnlyFeatured == true)
                query = query.Where(p => p.IsFeatured);

            if (filter.CategoryId.HasValue)
                query = query.Where(p => p.CategoryId == filter.CategoryId.Value);

            if (!string.IsNullOrWhiteSpace(filter.Search))
                query = query.Where(p => p.Name.Contains(filter.Search));

            return await query.ToListAsync(cancellationToken);
        }


        public async Task<Product> GetByIdWithIncludes(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Photos)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

    }
}
