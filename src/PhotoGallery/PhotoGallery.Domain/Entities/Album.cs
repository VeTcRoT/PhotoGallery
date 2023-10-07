namespace PhotoGallery.Domain.Entities
{
    public class Album : EntityBase
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Image> Images { get; set; } = 
            new List<Image>();
        public ICollection<UserAlbum> UserAlbums { get; set; } = 
            new List<UserAlbum>();
    }
}
