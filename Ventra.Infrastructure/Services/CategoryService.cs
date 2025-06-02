using Ventra.Domain.Entities;
using Ventra.Domain.Interfaces;
using Ventra.Infrastructure.Services.Interfaces;

namespace Ventra.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _repository;

        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        public async Task<Category> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        public async Task<Category> Add(Category category, CancellationToken cancellationToken)
        {
            _repository.Add(category);
            await _unitOfWork.Commit(cancellationToken);
            return category;
        }

        public async Task<Category> Update(Category category, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(category.Id, cancellationToken);

            if (entity == null)
            {
                return null;
            }

            entity.Name = category.Name;

            _repository.Update(entity);
            await _unitOfWork.Commit(cancellationToken);

            return entity;
        }

        public async Task<Category> Delete(Guid id, CancellationToken cancellationToken)
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
