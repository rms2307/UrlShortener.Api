using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Api.Models.Url;

namespace UrlShortener.Api.Infra.Data.EntitiesConfiguration
{
    public class UrlModelConfiguration : IEntityTypeConfiguration<UrlModel>
    {
        public void Configure(EntityTypeBuilder<UrlModel> builder)
        {
            builder.ToTable("Url");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnOrder(0);

            builder.Property(x => x.OriginalUrl)
                .IsRequired()
                .HasColumnOrder(1);

            builder.Property(x => x.BaseUrl)
                .IsRequired()
                .HasColumnOrder(2);
        }
    }
}
