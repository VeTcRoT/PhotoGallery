namespace PhotoGallery.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public int AlbumId { get; set; }
        public uint Likes { get; set; }
        public uint Dislikes { get; set; }

        public Album Album { get; set; } = null!;
    }
}
