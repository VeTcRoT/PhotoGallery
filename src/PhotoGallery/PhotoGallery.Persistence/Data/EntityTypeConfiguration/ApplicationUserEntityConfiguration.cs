using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Persistence.Data.EntityTypeConfiguration
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(user => user.Albums)
                .WithOne(album => album.User)
                .HasForeignKey(album => album.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
