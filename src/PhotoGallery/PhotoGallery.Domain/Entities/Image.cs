namespace PhotoGallery.Domain.Entities
{
    public class Image : EntityBase
    {
        public string FileName { get; set; } = string.Empty;
        public int AlbumId { get; set; }
        
        public Album Album { get; set; } = null!;
        public ICollection<Rate> Rate { get; set; } = new List<Rate>();
    }
}
