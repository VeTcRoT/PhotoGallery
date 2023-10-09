namespace PhotoGallery.Domain.Entities
{
    public class Album : EntityBase
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;

        public ICollection<Image> Images { get; set; } = 
            new List<Image>();
        public ApplicationUser User { get; set; } = null!;
    }
}
