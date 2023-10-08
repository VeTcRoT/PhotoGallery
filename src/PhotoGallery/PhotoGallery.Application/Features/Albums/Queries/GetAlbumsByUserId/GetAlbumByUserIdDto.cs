using PhotoGallery.Domain.Dtos;

namespace PhotoGallery.Application.Features.Albums.Queries.GetAlbumsByUserId
{
    public class GetAlbumByUserIdDto : AlbumDto 
    {
        public int Id { get; set; }
    }
}
