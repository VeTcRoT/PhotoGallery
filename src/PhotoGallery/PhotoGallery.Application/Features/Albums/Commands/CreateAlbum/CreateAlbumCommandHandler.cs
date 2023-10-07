using AutoMapper;
using MediatR;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Repositories;
using PhotoGallery.Domain.Interfaces.Services;

namespace PhotoGallery.Application.Features.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, CreateAlbumDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAlbumCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateAlbumDto> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var albumToAdd = _mapper.Map<Album>(request);
            albumToAdd.UserId = request.UserId;

            var createdAlbum = await _unitOfWork.AlbumRepository.CreateAsync(albumToAdd);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CreateAlbumDto>(createdAlbum);
        }
    }
}
