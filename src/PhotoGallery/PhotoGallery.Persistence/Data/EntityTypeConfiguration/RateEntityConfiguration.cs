using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Persistence.Data.EntityTypeConfiguration
{
    public class RateEntityConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasKey(rate => rate.Id);

            builder.HasIndex(rate => new { rate.ImageId, rate.UserId })
            .IsUnique();
        }
    }
}
