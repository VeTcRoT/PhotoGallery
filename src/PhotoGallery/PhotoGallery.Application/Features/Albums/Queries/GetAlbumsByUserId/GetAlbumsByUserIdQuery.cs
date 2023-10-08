using MediatR;

namespace PhotoGallery.Application.Features.Albums.Queries.GetAlbumsByUserId
{
    public class GetAlbumsByUserIdQuery : IRequest<IReadOnlyCollection<GetAlbumsByUserIdDto>>
    {
        public string UserId { get; set; } = string.Empty;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
