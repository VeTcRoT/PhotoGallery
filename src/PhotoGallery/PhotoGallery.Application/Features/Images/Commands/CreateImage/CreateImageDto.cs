namespace PhotoGallery.Application.Features.Images.Commands.CreateImage
{
    public class CreateImageDto
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public uint Likes { get; set; }
        public uint Dislikes { get; set; }
    }
}
