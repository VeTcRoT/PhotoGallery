namespace PhotoGallery.Application.Features.Albums.Commands.CreateAlbum
{
    public class CreateAlbumDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
