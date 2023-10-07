using PhotoGallery.Domain.Dtos;

namespace PhotoGallery.Application.Features.Albums.Commands.CreateAlbum
{
    public class CreateAlbumDto : AlbumDto
    {
        public int Id { get; set; }
    }
}
