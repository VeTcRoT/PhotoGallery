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
        private readonly IUserService _userService;

        public DeleteImageCommandHandler(IUnitOfWork unitOfWork, IImageService imageService, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
            _userService = userService;
        }

        public async Task Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var imageToDelete = await _unitOfWork.ImageRepository.GetByIdWithAlbumAsync(request.Id);

            if (imageToDelete == null)
            {
                throw new ArgumentException(
                    $"Image with id: {request.Id} can't be found.", nameof(request.Id));
            }

            if (imageToDelete.Album.UserId != request.UserId 
                && !await _userService.IsAdminAsync(request.UserId))
            {
                throw new ArgumentException("User have no rights delete image.", nameof(request.UserId));
            }

            _imageService.DeleteImage(imageToDelete.FileName);

            _unitOfWork.ImageRepository.Delete(imageToDelete);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
