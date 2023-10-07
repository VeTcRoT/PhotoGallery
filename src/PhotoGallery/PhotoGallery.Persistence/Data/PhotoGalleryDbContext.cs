using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Persistence.Data
{
    public class PhotoGalleryDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Album> Albums { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<Rate> Rates { get; set; } = null!;

        public PhotoGalleryDbContext(DbContextOptions<PhotoGalleryDbContext> options) : base(options)
        { }
    }
}
