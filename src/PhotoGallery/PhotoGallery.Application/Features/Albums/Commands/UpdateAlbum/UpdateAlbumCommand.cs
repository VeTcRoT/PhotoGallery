using MediatR;

namespace PhotoGallery.Application.Features.Albums.Commands.UpdateAlbum
{
    public class UpdateAlbumCommand : IRequest<UpdateAlbumDto>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
