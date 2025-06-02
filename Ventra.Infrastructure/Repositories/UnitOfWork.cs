using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Interfaces;
using Ventra.Infrastructure.Context;

namespace Ventra.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VentraDbContext _context;

        public UnitOfWork(VentraDbContext context)
        {
            _context = context;
        }
        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
