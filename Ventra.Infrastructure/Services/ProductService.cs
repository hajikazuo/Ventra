using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventra.Domain.Entities;
using Ventra.Domain.Interfaces;
using Ventra.Infrastructure.CrossCutting.Interfaces;
using Ventra.Infrastructure.Services.Interfaces;

namespace Ventra.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _repository;
        private readonly IPhotoService _photoService;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository repository, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _photoService = photoService;
        }

        public async Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        public async Task<Product> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdWithIncludes(id, cancellationToken);
        }

        public async Task<Product> Add(Product product, List<IFormFile> files,string folderPath, CancellationToken cancellationToken)
        {
            _repository.Add(product);

            foreach (var file in files)
            {
                var photo = await _photoService.UploadPhoto(folderPath, product.Id, file, cancellationToken);
                product.Photos.Add(photo); 
            }
            
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
