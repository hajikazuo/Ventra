using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Entities;

namespace Ventra.Domain.Interfaces
{
    public interface IPhotoRepository : IBaseRepository<Photo>
    {
        Task<IEnumerable<Photo>> GetAllWithFilter(Guid id, CancellationToken cancellationToken);
    }
}
