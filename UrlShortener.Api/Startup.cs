using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UrlShortener.Api.Infra.Cache;
using UrlShortener.Api.Infra.Cache.Interfaces;
using UrlShortener.Api.Infra.Data.Context;
using UrlShortener.Api.Infra.Data.Repositories;
using UrlShortener.Api.Infra.Data.Repositories.Interfaces;
using UrlShortener.Api.Models.Url;
using UrlShortener.Api.Services;
using UrlShortener.Api.Services.Interfaces;

namespace UrlShortener.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["ConnectionStrings:ConnectionString"];
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connection)
            );

            services.AddScoped<IUrlRepository, UrlRepository>();

            services.AddScoped<IUrlService, UrlService>();

            services.AddTransient<ICache<UrlModel>, Cache<UrlModel>>();

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration =
                    Configuration.GetValue<string>("CacheConfig:ConnectionCache");
                options.InstanceName = "UrlShortener.Api";
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UrlShortener.Api", Version = "v1" });
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UrlShortener.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
