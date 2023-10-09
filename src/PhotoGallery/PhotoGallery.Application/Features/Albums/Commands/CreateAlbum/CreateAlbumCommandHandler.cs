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
        private readonly IUserService _userService;

        public CreateAlbumCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IUserService userService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<CreateAlbumDto> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(request.UserId);

            if (user == null)
            {
                throw new ArgumentException($"User with id: {request.UserId} does not exist.", nameof(request.UserId));
            }

            var albumToAdd = _mapper.Map<Album>(request);
            albumToAdd.User = user;

            var createdAlbum = await _unitOfWork.AlbumRepository.CreateAsync(albumToAdd);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CreateAlbumDto>(createdAlbum);
        }
    }
}
