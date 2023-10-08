namespace PhotoGallery.Application.Features.Albums.Queries.GetAlbumsByUserId
{
    public class GetAlbumsByUsedIdQuery
    {
        public string UserId { get; set; } = string.Empty;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
