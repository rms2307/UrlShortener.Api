using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Api.Models;

namespace UrlShortener.Api.Infra.Data.EntitiesConfiguration
{
    public class FeatureToggleConfiguration : IEntityTypeConfiguration<FeatureToggle>
    {
        public void Configure(EntityTypeBuilder<FeatureToggle> builder)
        {
            builder.ToTable("FeatureToggle");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnOrder(0);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnOrder(1);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnOrder(2);

            builder.Property(x => x.Status)
               .IsRequired()
               .HasColumnOrder(3);
        }
    }
}
