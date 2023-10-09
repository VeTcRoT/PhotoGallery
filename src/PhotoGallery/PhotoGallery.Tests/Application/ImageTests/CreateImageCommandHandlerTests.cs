using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moq;
using PhotoGallery.Application.Features.Images.Commands.CreateImage;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Domain.Interfaces.Services;

namespace PhotoGallery.Tests.Application.ImageTests
{
    public class CreateImageCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IImageService> _imageServiceMock;
        private readonly Mock<IMapper> _mapperMock;

        public CreateImageCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _imageServiceMock = new Mock<IImageService>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task Handle_Invoke_CreatesImageSuccessfully()
        {
            // Arrange
            var albumId = 1;
            var userId = "1234";
            var imageMock = new Mock<IFormFile>();
            var request = new CreateImageCommand { AlbumId = albumId, UserId = userId, Image = imageMock.Object };

            var album = new Album { Id = albumId, UserId = userId };
            var imageToAdd = new Image { FileName = "image.jpg", Album = album };
            var createdImage = new Image();
            var createImageDto = new CreateImageDto();


            _unitOfWorkMock.Setup(u => u.AlbumRepository.GetByIdAsync(albumId)).ReturnsAsync(album);
            _imageServiceMock.Setup(i => i.UploadImageAsync(request.Image)).ReturnsAsync("image.jpg");
            _unitOfWorkMock.Setup(u => u.ImageRepository.CreateAsync(It.IsAny<Image>())).ReturnsAsync(createdImage);
            _mapperMock.Setup(m => m.Map<CreateImageDto>(createdImage)).Returns(createImageDto);

            var handler = new CreateImageCommandHandler(
                _mapperMock.Object,
                _unitOfWorkMock.Object,
                _imageServiceMock.Object
            );

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            _unitOfWorkMock.Verify(u => u.AlbumRepository.GetByIdAsync(albumId), Times.Once);
            _imageServiceMock.Verify(i => i.UploadImageAsync(request.Image), Times.Once);
            _unitOfWorkMock.Verify(u => u.ImageRepository.CreateAsync(It.IsAny<Image>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
            _mapperMock.Verify(u => u.Map<CreateImageDto>(createdImage));

            Assert.Equal(createImageDto, result);
        }

        [Fact]
        public async Task Handle_InvokeWithInvalidAlbumId_ThrowsArgumentException()
        {
            // Arrange
            var albumId = 1;
            var request = new CreateImageCommand { AlbumId = albumId};

            _unitOfWorkMock.Setup(u => u.AlbumRepository.GetByIdAsync(albumId)).ReturnsAsync(null as Album);

            var handler = new CreateImageCommandHandler(
                _mapperMock.Object,
                _unitOfWorkMock.Object,
                _imageServiceMock.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(request, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_InvokeWithUnauthorizedUser_ThrowsArgumentException()
        {
            // Arrange
            var albumId = 1;
            var userId = "1234";
            var request = new CreateImageCommand { AlbumId = albumId, UserId = userId };

            var album = new Album { Id = albumId, UserId = "123" };

            _unitOfWorkMock.Setup(u => u.AlbumRepository.GetByIdAsync(albumId)).ReturnsAsync(album);

            var handler = new CreateImageCommandHandler(
                _mapperMock.Object,
                _unitOfWorkMock.Object,
                _imageServiceMock.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(request, CancellationToken.None));
        }
    }
}
