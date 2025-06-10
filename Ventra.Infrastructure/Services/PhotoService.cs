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
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoRepository _repository;
        private readonly IUploadService _uploadService;

        public PhotoService(IUnitOfWork unitOfWork, IPhotoRepository repository, IUploadService uploadService)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _uploadService = uploadService;
        }

        public async Task<IEnumerable<Photo>> GetAll(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetAllWithFilter(id, cancellationToken);
        }

        public async Task Add(Guid id, List<IFormFile> files, string folderPath, CancellationToken cancellationToken)
        {
            foreach (var file in files)
            {
                var photo = await _uploadService.UploadPhoto(folderPath, id, file, cancellationToken);
                _repository.Add(photo);
            }

            await _unitOfWork.Commit(cancellationToken);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(id, cancellationToken);
            _repository.Delete(entity);
            await _unitOfWork.Commit(cancellationToken);
        }
    }
}
