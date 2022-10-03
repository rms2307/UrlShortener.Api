using System.Threading.Tasks;

namespace UrlShortener.Api.Infra.Cache.Interfaces
{
    public interface ICache<TModel>
    {
        Task<TModel> GetCacheAsync(string key);
        Task AddCacheAsync(string key, TModel obj);
        Task RemoveCacheAsync(string key);
    }
}
