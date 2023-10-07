namespace PhotoGallery.Domain.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public int Description { get; set; }
        public string FolderName { get; set; } = string.Empty;

        public ICollection<Image> Images { get; set; } = 
            new List<Image>();
        public ICollection<UserAlbum> UserAlbums { get; set; } = 
            new List<UserAlbum>();
    }
}
