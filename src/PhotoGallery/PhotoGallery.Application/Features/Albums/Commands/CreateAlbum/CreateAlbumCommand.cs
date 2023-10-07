using MediatR;
using PhotoGallery.Domain.Dtos;

namespace PhotoGallery.Application.Features.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommand : IRequest<AlbumDto>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
