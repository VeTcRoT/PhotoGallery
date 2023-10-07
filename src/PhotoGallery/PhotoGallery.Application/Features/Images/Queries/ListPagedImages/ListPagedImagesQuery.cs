using MediatR;

namespace PhotoGallery.Application.Features.Images.Queries.ListPagedImages
{
    public class ListPagedImagesQuery : IRequest<ListPagedImageDto>
    {
        public int AlbumId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
