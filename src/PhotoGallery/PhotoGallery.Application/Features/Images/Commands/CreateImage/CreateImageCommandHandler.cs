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
            var albumRepo = _unitOfWork.GetRepository<Album>();

            var album = await albumRepo.GetByIdAsync(request.AlbumId);

            if (album == null)
            {
                throw new ArgumentException(
                    $"Album with id: {request.AlbumId} can't be found.", nameof(request.AlbumId));
            }

            await _imageService.UploadImageAsync(request.Image);

            var imageRepo = _unitOfWork.GetRepository<Image>();

            var imageToAdd = _mapper.Map<Image>(request);

            var image = await imageRepo.CreateAsync(imageToAdd);

            return _mapper.Map<CreateImageDto>(image);
        }
    }
}
