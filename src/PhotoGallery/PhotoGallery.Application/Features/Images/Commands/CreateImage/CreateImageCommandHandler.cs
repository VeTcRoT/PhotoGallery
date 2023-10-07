using AutoMapper;
using MediatR;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Domain.Interfaces.Services;

namespace PhotoGallery.Application.Features.Images.Commands.CreateImage
{
    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, CreateImageDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public CreateImageCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IImageService imageService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }

        public async Task<CreateImageDto> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var album = await _unitOfWork.AlbumRepository.GetByIdAsync(request.AlbumId);

            if (album == null)
            {
                throw new ArgumentException(
                    $"Album with id: {request.AlbumId} can't be found.", nameof(request.AlbumId));
            }

            if (album.UserId != request.UserId)
            {
                throw new ArgumentException("User have no rights to add image to this album.", nameof(request.UserId));
            }

            var imagePath = await _imageService.UploadImageAsync(request.Image);

            var imageToAdd = new Image
            {
                FileName = imagePath,
                Album = album
            };

            var image = await _unitOfWork.ImageRepository.CreateAsync(imageToAdd);

            return _mapper.Map<CreateImageDto>(image);
        }
    }
}
