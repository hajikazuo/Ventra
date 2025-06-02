using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Entities;
using Ventra.Domain.Interfaces;
using Ventra.Infrastructure.Services.Interfaces;

namespace Ventra.Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientRepository _repository;

        public ClientService(IUnitOfWork unitOfWork, IClientRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<IEnumerable<Client>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        public async Task<Client> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        public async Task<Client> Add(Client client, CancellationToken cancellationToken)
        {
            _repository.Add(client);
            await _unitOfWork.Commit(cancellationToken);
            return client;
        }

        public async Task<Client> Update(Client client, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(client.Id, cancellationToken);

            if (entity == null)
            {
                return null;
            }

            entity.Name = client.Name;
            entity.DateBirth = client.DateBirth;
            entity.CPF = client.CPF;
            entity.Telephone = client.Telephone;
            entity.Email = client.Email;
            entity.Status = client.Status;

            _repository.Update(entity);
            await _unitOfWork.Commit(cancellationToken);

            return entity;
        }

        public async Task<Client> Delete(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(id, cancellationToken);

            if (entity == null)
            {
                return null;
            }

            _repository.Delete(entity);
            await _unitOfWork.Commit(cancellationToken);

            return entity;
        }
    }
}
