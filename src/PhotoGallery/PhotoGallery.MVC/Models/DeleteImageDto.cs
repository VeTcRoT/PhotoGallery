namespace PhotoGallery.MVC.Models
{
    public class DeleteImageDto
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
