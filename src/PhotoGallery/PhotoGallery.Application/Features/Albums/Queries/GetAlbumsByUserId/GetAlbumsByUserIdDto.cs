using PhotoGallery.Domain.Dtos;

namespace PhotoGallery.Application.Features.Albums.Queries.GetAlbumsByUserId
{
    public class GetAlbumsByUserIdDto : AlbumDto 
    {
        public int Id { get; set; }
    }
}
