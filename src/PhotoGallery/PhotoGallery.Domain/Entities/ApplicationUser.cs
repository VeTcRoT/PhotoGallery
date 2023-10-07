using Microsoft.AspNetCore.Identity;

namespace PhotoGallery.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Album> UserAlbums { get; set; } = 
            new List<Album>();
    }
}
