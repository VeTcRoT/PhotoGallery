using MediatR;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Domain.Interfaces.Services;

namespace PhotoGallery.Application.Features.Images.Commands.DeleteImage
{
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public DeleteImageCommandHandler(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }

        public async Task Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Image>();

            var imageToDelete = await repo.GetByIdAsync(request.Id);

            if (imageToDelete == null)
            {
                throw new ArgumentException(
                    $"Image with id: {request.Id} can't be found.", nameof(request.Id));
            }

            _imageService.DeleteImage(imageToDelete.FileName);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
