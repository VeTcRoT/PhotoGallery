using AutoMapper;
using MediatR;
using PhotoGallery.Domain.Dtos;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Repositories;

namespace PhotoGallery.Application.Features.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, AlbumDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAlbumCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AlbumDto> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Album>();
            var albumToUpdate = await repo.GetByIdAsync(request.Id);

            if (albumToUpdate == null)
            {
                throw new ArgumentException(
                    $"Album with id: {request.Id} can't be found.", nameof(request.Id));
            }

            _mapper.Map(request, albumToUpdate, typeof(UpdateAlbumCommand), typeof(Album));

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AlbumDto>(albumToUpdate);
        }
    }
}
