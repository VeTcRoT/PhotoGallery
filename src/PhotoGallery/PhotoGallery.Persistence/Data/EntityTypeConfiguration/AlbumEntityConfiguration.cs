using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Persistence.Data.EntityTypeConfiguration
{
    public class AlbumEntityConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(album => album.Id);

            builder.HasMany(album => album.Images)
                .WithOne(image => image.Album)
                .HasForeignKey(image => image.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
