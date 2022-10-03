using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using UrlShortener.Api.Infra.Cache.Interfaces;

namespace UrlShortener.Api.Infra.Cache
{
    public class Cache<TModel> : ICache<TModel>
    {
        private readonly IDistributedCache _cache;
        private readonly IConfiguration _configuration;

        private DistributedCacheEntryOptions _distributedCacheEntryOptions;

        public Cache(IDistributedCache cache, IConfiguration configuration)
        {
            _cache = cache;
            _configuration = configuration;
            GetCacheEntryOptions();
        }

        public async Task<TModel> GetCacheAsync(string key)
        {
            var objString = await _cache.GetStringAsync(key);

            if (string.IsNullOrEmpty(objString)) return default;

            return JsonSerializer.Deserialize<TModel>(objString)!;
        }

        public async Task AddCacheAsync(string key, TModel obj)
        {
            if (string.IsNullOrEmpty(key) || obj is null) return;

            var objString = JsonSerializer.Serialize(obj);

            await _cache.SetStringAsync(key, objString, _distributedCacheEntryOptions);
        }

        public async Task RemoveCacheAsync(string key)
        {
            if (string.IsNullOrEmpty(key)) return;

            var exists = await _cache.GetAsync(key) is not null;

            if (exists)
                await _cache.RemoveAsync(key);
        }

        private void GetCacheEntryOptions()
        {
            var absoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_configuration.GetValue<int>("CacheConfig:AbsoluteExpirationRelativeToNow"));
            var slidingExpiration = TimeSpan.FromMinutes(_configuration.GetValue<int>("CacheConfig:SlidingExpiration"));
            _distributedCacheEntryOptions = new() { AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow, SlidingExpiration = slidingExpiration };
        }
    }
}
