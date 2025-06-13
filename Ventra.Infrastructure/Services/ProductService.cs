using Ventra.Domain.Entities;
using Ventra.Domain.Interfaces;
using Ventra.Infrastructure.Services.Interfaces;

namespace Ventra.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _repository;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAllWithIncludes(cancellationToken);
        }

        public async Task<Product> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdWithIncludes(id, cancellationToken);
        }

        public async Task<Product> Add(Product product, CancellationToken cancellationToken)
        {
            _repository.Add(product);
            await _unitOfWork.Commit(cancellationToken);
            return product;
        }

        public async Task<Product> Update(Product product, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(product.Id, cancellationToken);

            if (entity == null)
            {
                return null;
            }

            entity.Name = product.Name;
            entity.Description = product.Description;
            entity.Price = product.Price;
            entity.Stock = product.Stock;
            entity.CategoryId = product.CategoryId;

            _repository.Update(entity);
            await _unitOfWork.Commit(cancellationToken);

            return entity;
        }

        public async Task<Product> Delete(Guid id, CancellationToken cancellationToken)
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
