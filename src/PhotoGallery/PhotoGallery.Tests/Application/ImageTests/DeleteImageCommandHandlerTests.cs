using Moq;
using PhotoGallery.Application.Features.Images.Commands.DeleteImage;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Domain.Interfaces.Services;

namespace PhotoGallery.Tests.Application.ImageTests
{
    public class DeleteImageCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IImageService> _imageServiceMock;
        private readonly Mock<IUserService> _userServiceMock;

        public DeleteImageCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _imageServiceMock = new Mock<IImageService>();
            _userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public async Task Handle_Invoke_DeletesImageSuccessfully()
        {
            // Arrange
            var imageId = 1;
            var userId = "1234";
            var request = new DeleteImageCommand { Id = imageId, UserId = userId };

            var imageToDelete = new Image { Id = imageId, FileName = "image.jpg", Album = new Album { UserId = userId } };

            _unitOfWorkMock.Setup(u => u.ImageRepository.GetByIdWithAlbumAsync(imageId)).ReturnsAsync(imageToDelete);
            _userServiceMock.Setup(u => u.IsAdminAsync(userId)).ReturnsAsync(false);

            var handler = new DeleteImageCommandHandler(
                _unitOfWorkMock.Object,
                _imageServiceMock.Object,
                _userServiceMock.Object
            );

            // Act
            await handler.Handle(request, CancellationToken.None);

            // Assert
            _unitOfWorkMock.Verify(u => u.ImageRepository.GetByIdWithAlbumAsync(imageId), Times.Once);
            _imageServiceMock.Verify(i => i.DeleteImage(imageToDelete.FileName), Times.Once);
            _unitOfWorkMock.Verify(u => u.ImageRepository.Delete(imageToDelete), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_InvokeWithInvalidImageId_ThrowsArgumentException()
        {
            // Arrange
            var imageId = 1;
            var request = new DeleteImageCommand { Id = imageId };

            _unitOfWorkMock.Setup(u => u.ImageRepository.GetByIdWithAlbumAsync(imageId)).ReturnsAsync(null as Image);

            var handler = new DeleteImageCommandHandler(
                _unitOfWorkMock.Object,
                _imageServiceMock.Object,
                _userServiceMock.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_InvokeWithUnauthorizedUser_ThrowsArgumentException()
        {
            // Arrange
            var imageId = 1;
            var userId = "1234";
            var request = new DeleteImageCommand { Id = imageId, UserId = userId };

            var imageToDelete = new Image { Id = imageId, Album = new Album { UserId = "123" } };

            _unitOfWorkMock.Setup(u => u.ImageRepository.GetByIdWithAlbumAsync(imageId)).ReturnsAsync(imageToDelete);

            var handler = new DeleteImageCommandHandler(
                _unitOfWorkMock.Object,
               _imageServiceMock.Object,
                _userServiceMock.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(request, CancellationToken.None));
        }
    }
}
