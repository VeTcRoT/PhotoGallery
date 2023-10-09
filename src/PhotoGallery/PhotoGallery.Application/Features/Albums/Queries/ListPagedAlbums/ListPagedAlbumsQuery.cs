using MediatR;
using PhotoGallery.Domain.Helpers;

namespace PhotoGallery.Application.Features.Albums.Queries.ListPagedAlbums
{
    public class ListPagedAlbumsQuery : IRequest<PagedList<ListPagedAlbumsDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
