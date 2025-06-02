using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Entities;

namespace Ventra.Infrastructure.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAll(CancellationToken cancellationToken);
        Task<Client> GetById(Guid id, CancellationToken cancellationToken);
        Task<Client> Add(Client client, CancellationToken cancellationToken);
        Task<Client> Update(Client client, CancellationToken cancellationToken);
        Task<Client> Delete(Guid id, CancellationToken cancellationToken);
    }
}
