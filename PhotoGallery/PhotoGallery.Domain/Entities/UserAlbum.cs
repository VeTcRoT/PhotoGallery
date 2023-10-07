namespace PhotoGallery.Domain.Entities
{
    public class UserAlbum
    {
        public int UserId { get; set; }
        public int AlbumId { get; set; }

        public ApplicationUser User { get; set; } = null!;
        public Album Album { get; set; } = null!;
    }
}
