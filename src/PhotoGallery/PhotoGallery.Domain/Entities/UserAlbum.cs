namespace PhotoGallery.Domain.Entities
{
    public class UserAlbum : EntityBase
    {
        public string UserId { get; set; } = string.Empty;
        public int AlbumId { get; set; }

        public ApplicationUser User { get; set; } = null!;
        public Album Album { get; set; } = null!;
    }
}
