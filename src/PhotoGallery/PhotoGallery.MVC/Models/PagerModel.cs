using PhotoGallery.Domain.Helpers;

namespace PhotoGallery.MVC.Models
{
    public class PagerModel
    {
        public IPageData PageData { get; set; } = null!;
        public string Controller { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public IDictionary<string, string> QueryParameters { get; set; } = null!;
    }
}
