using Microsoft.EntityFrameworkCore;
using RT.Comb;
using Ventra.Domain.Entities;
using Ventra.Domain.Interfaces;
using Ventra.Infrastructure.Context;

namespace Ventra.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly VentraDbContext _context;
        private readonly ICombProvider _comb;

        public BaseRepository(VentraDbContext context, ICombProvider comb)
        {
            _context = context;
            _comb = comb;
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Add(T entity)
        {
            entity.Id = _comb.Create();
            entity.DateCreated = DateTimeOffset.UtcNow;
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            entity.DateUpdated = DateTimeOffset.UtcNow;
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }
    }
}
