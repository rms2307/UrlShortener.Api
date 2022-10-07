using Microsoft.EntityFrameworkCore;
using UrlShortener.Api.Models;
using UrlShortener.Api.Models.Url;

namespace UrlShortener.Api.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<UrlModel> UrlModels { get; set; }
        public DbSet<FeatureToggle> FeatureToggles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
