namespace PhotoGallery.Domain.Entities
{
    public class Rate : EntityBase
    {
        public int ImageId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public bool IsLike { get; set; }
    }
}
