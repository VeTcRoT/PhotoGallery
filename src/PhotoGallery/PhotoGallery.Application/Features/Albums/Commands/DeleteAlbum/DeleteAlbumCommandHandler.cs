using MediatR;
using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Domain.Interfaces.Services;

namespace PhotoGallery.Application.Features.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;
        private readonly IUserService _userService;

        public DeleteAlbumCommandHandler(IUnitOfWork unitOfWork, IImageService imageService, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
            _userService = userService;
        }

        public async Task Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            var albumToDelete = 
                await _unitOfWork.AlbumRepository.GetAlbumWithImagesAsync(request.Id);

            if (albumToDelete == null) 
            {
                throw new ArgumentException(
                    $"Album with id: {request.Id} can't be found.", nameof(request.Id));
            }

            if (albumToDelete.UserId != request.UserId && !await _userService.IsAdminAsync(request.UserId))
            {
                throw new ArgumentException("User have no rights to delete album.", nameof(request.UserId));
            }

            _imageService.DeleteImages(albumToDelete.Images.Select(i => i.FileName));

            _unitOfWork.AlbumRepository.Delete(albumToDelete);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
