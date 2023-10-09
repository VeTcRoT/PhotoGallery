using AutoMapper;
using Moq;
using PhotoGallery.Application.Features.Albums.Commands.CreateAlbum;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Domain.Interfaces.Services;

namespace PhotoGallery.Tests.Application.CreateAlbum
{
    public class CreateAlbumCommandHandlerTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IUserService> _userServiceMock;

        public CreateAlbumCommandHandlerTests()
        {
            _mapperMock = new Mock<IMapper>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public async Task Handle_Invoke_CreatesAlbumSuccessfully()
        {
            //Arrange
            var userId = "1234";

            var request = new CreateAlbumCommand { UserId = userId };
            var user = new ApplicationUser();
            var albumToAdd = new Album();
            var createdAlbum = new Album();
            var createAlbumDto = new CreateAlbumDto();

            _mapperMock.Setup(m => m.Map<Album>(request)).Returns(albumToAdd);
            _unitOfWorkMock.Setup(u => u.AlbumRepository.CreateAsync(albumToAdd)).ReturnsAsync(createdAlbum);
            _mapperMock.Setup(m => m.Map<CreateAlbumDto>(createdAlbum)).Returns(createAlbumDto);
            _userServiceMock.Setup(u => u.GetUserByIdAsync(userId)).ReturnsAsync(user);

            var handler = new CreateAlbumCommandHandler(
                _mapperMock.Object,
                _unitOfWorkMock.Object,
                _userServiceMock.Object
            );

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            _mapperMock.Verify(m => m.Map<Album>(request), Times.Once);
            _mapperMock.Verify(m => m.Map<CreateAlbumDto>(createdAlbum), Times.Once);
            _unitOfWorkMock.Verify(u => u.AlbumRepository.CreateAsync(albumToAdd), Times.Once);
            _userServiceMock.Verify(u => u.GetUserByIdAsync(userId), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);

            Assert.Equal(result, createAlbumDto);
        }

        [Fact]
        public async Task Handle_InvokeWithNullApplicationUser_ThrowsArgumentException()
        {
            // Arrange
            var request = new CreateAlbumCommand();

            _userServiceMock.Setup(u => u.GetUserByIdAsync(It.IsAny<string>())).ReturnsAsync(null as ApplicationUser);

            var handler = new CreateAlbumCommandHandler(
                _mapperMock.Object,
                _unitOfWorkMock.Object,
                _userServiceMock.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(request, CancellationToken.None));
        }
    }
}
