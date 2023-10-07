using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PhotoGallery.Domain.Dtos;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Repositories;

namespace PhotoGallery.Application.Features.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, CreateAlbumDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateAlbumCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<CreateAlbumDto> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null)
            {
                throw new ArgumentException(
                    $"User with this id: {request.UserId} can't be found.");
            }

            var albumToAdd = _mapper.Map<Album>(request);

            var repo = _unitOfWork.GetRepository<UserAlbum>();

            var userAlbumToAdd = new UserAlbum
            {
                User = user,
                Album = albumToAdd,
            };

            var userAlbum = await repo.CreateAsync(userAlbumToAdd);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CreateAlbumDto>(userAlbum.Album);
        }
    }
}
