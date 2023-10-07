using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Persistence.Data.EntityTypeConfiguration
{
    public class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(image => image.Id);

            builder.HasMany(image => image.Rate)
                .WithOne(rate => rate.Image)
                .HasForeignKey(rate => rate.ImageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
