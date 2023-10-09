using MediatR;
using PhotoGallery.Domain.Helpers;

namespace PhotoGallery.Application.Features.Albums.Queries.GetAlbumsByUserId
{
    public class GetAlbumsByUserIdQuery : IRequest<PagedList<GetAlbumsByUserIdDto>>
    {
        public string UserId { get; set; } = string.Empty;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
