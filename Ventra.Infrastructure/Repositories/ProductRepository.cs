using Microsoft.EntityFrameworkCore;
using RT.Comb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Product> GetByIdWithIncludes(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Photos)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

    }
}
