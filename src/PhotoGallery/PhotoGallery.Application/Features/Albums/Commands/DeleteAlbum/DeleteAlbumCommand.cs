using MediatR;

namespace PhotoGallery.Application.Features.Albums.Commands.DeleteAlbum
{
    public class DeleteAlbumCommand : IRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
