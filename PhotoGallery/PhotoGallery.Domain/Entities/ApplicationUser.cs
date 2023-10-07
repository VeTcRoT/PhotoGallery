using Microsoft.AspNetCore.Identity;

namespace PhotoGallery.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserAlbum> UserAlbums { get; set; } = 
            new List<UserAlbum>();
    }
}
