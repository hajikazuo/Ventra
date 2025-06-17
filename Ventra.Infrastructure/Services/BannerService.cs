using Microsoft.AspNetCore.Http;
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
    public class BannerService : IBannerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBannerRepository _repository;
        private readonly IUploadService _uploadService;

        public BannerService(IUnitOfWork unitOfWork, IBannerRepository repository, IUploadService uploadService)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _uploadService = uploadService;
        }

        public async Task<IEnumerable<Banner>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        public async Task<Banner> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        public async Task Add(List<IFormFile> files, string folderPath, CancellationToken cancellationToken)
        {
            foreach (var file in files)
            {
                var banner = await _uploadService.UploadBanner(folderPath, file, cancellationToken);
                _repository.Add(banner);
            }

            await _unitOfWork.Commit(cancellationToken);
        }

        public async Task<Banner> Update(Banner banner, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(banner.Id, cancellationToken);

            if (entity == null)
            {
                return null;
            }

            entity.IsActive = banner.IsActive;

            _repository.Update(entity);
            await _unitOfWork.Commit(cancellationToken);

            return entity;
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(id, cancellationToken);
            _repository.Delete(entity);
            await _unitOfWork.Commit(cancellationToken);
        }
    }
}
