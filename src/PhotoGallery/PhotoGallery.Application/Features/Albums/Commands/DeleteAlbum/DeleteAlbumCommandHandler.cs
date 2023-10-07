using MediatR;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Repositories;

namespace PhotoGallery.Application.Features.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumCommandHandler : IRequestHandler<DeleteAlbumCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAlbumCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteAlbumCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Album>();

            var albumToDelete = await repo.GetByIdAsync(request.Id);

            if (albumToDelete == null) 
            {
                throw new ArgumentException(
                    $"Album with id: {request.Id} can't be found.", nameof(request.Id));
            }

            repo.Delete(albumToDelete);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
