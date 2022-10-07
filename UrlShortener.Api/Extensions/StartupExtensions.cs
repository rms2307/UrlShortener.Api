using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Api.Infra.Cache;
using UrlShortener.Api.Infra.Cache.Interfaces;
using UrlShortener.Api.Infra.Data.Repositories;
using UrlShortener.Api.Infra.Data.Repositories.Interfaces;
using UrlShortener.Api.Models.Url;
using UrlShortener.Api.Services;
using UrlShortener.Api.Services.Interfaces;

namespace UrlShortener.Api.Extensions
{
    public static class StartupExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUrlRepository, UrlRepository>();
            services.AddScoped<IFeatureToggleRepository, FeatureToggleRepository>();
        }

        public static void AddCache(this IServiceCollection services)
        {
            services.AddTransient<ICache<UrlModel>, Cache<UrlModel>>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUrlService, UrlService>();
            services.AddScoped<IFeatureToggleService, FeatureToggleService>();
        }
    }
}
