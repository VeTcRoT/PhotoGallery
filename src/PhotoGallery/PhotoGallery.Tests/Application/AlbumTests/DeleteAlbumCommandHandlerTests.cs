using Moq;
using PhotoGallery.Application.Features.Albums.Commands.DeleteAlbum;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Domain.Interfaces.Services;

namespace PhotoGallery.Tests.Application.CreateAlbum
{
    public class DeleteAlbumCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IImageService> _imageServiceMock;
        private readonly Mock<IUserService> _userServiceMock;

        public DeleteAlbumCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _imageServiceMock = new Mock<IImageService>();
            _userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public async Task Handle_Invoke_DeletesAlbumSuccessfully()
        {
            //Arrange

            var albumId = 1;
            var userId = "1234";
            var request = new DeleteAlbumCommand { Id = albumId, UserId = userId };

            var albumToDelete = new Album
            {
                Id = albumId,
                UserId = userId
            };

            _unitOfWorkMock.Setup(u => u.AlbumRepository.GetAlbumWithImagesAsync(albumId)).ReturnsAsync(albumToDelete);
            _userServiceMock.Setup(u => u.IsAdminAsync(userId)).ReturnsAsync(false);

            var handler = new DeleteAlbumCommandHandler(
                _unitOfWorkMock.Object,
                _imageServiceMock.Object,
                _userServiceMock.Object
            );

            // Act
            await handler.Handle(request, CancellationToken.None);

            // Assert
            _unitOfWorkMock.Verify(u => u.AlbumRepository.GetAlbumWithImagesAsync(albumId), Times.Once);
            _imageServiceMock.Verify(i => i.DeleteImages(It.IsAny<IEnumerable<string>>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.AlbumRepository.Delete(albumToDelete), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_InvokeWithNullAlbum_ThrowsArgumentException()
        {
            // Arrange
            var albumId = 1;
            var request = new DeleteAlbumCommand { Id = albumId };

            _unitOfWorkMock.Setup(u => u.AlbumRepository.GetAlbumWithImagesAsync(albumId)).ReturnsAsync(null as Album);

            var handler = new DeleteAlbumCommandHandler(
                _unitOfWorkMock.Object,
                _imageServiceMock.Object,
                _userServiceMock.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_InvokeWithBadUserId_ThrowsArgumentException()
        {
            // Arrange
            var albumId = 1;
            var userId = "1234";
            var request = new DeleteAlbumCommand { Id = albumId, UserId = userId };

            var albumToDelete = new Album
            {
                Id = albumId,
                UserId = "123"
            };

            _unitOfWorkMock.Setup(u => u.AlbumRepository.GetAlbumWithImagesAsync(albumId)).ReturnsAsync(albumToDelete);
            _userServiceMock.Setup(u => u.IsAdminAsync(userId)).ReturnsAsync(false);

            var handler = new DeleteAlbumCommandHandler(
                _unitOfWorkMock.Object,
                _imageServiceMock.Object,
                _userServiceMock.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(request, CancellationToken.None));
        }
    }
}
