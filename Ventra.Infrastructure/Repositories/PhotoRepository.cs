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
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(VentraDbContext context, ICombProvider comb) : base(context, comb)
        {
        }

        public async Task<IEnumerable<Photo>> GetAllWithFilter(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Photos.Include(p => p.Product).Where(p => p.ProductId == id).ToListAsync(cancellationToken);
        }
    }
}
