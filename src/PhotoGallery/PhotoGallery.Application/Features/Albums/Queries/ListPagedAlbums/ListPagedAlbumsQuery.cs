using MediatR;

namespace PhotoGallery.Application.Features.Albums.Queries.ListPagedAlbums
{
    public class ListPagedAlbumsQuery : IRequest<IReadOnlyCollection<ListPagedAlbumsDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
