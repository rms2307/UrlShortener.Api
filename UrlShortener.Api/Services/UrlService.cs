using System.Threading.Tasks;
using UrlShortener.Api.Extensions;
using UrlShortener.Api.Infra.Cache.Interfaces;
using UrlShortener.Api.Infra.Data.Repositories.Interfaces;
using UrlShortener.Api.Models.Url;
using UrlShortener.Api.Services.Interfaces;

namespace UrlShortener.Api.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _urlRepository;
        private readonly ICache<UrlModel> _cache;

        public UrlService(IUrlRepository urlRepository, ICache<UrlModel> cache)
        {
            _urlRepository = urlRepository;
            _cache = cache;
        }

        public async Task<UrlResponseModel> GetOriginalUrl(string suffixShortenedUrl)
        {
            var id = ShortUrlHelper.Decode(suffixShortenedUrl);
            var cacheKey = $"UrlModel:{id}-{suffixShortenedUrl}";

            UrlModel urlModel = await _cache.GetCacheAsync(cacheKey);

            if (urlModel is null)
            {
                urlModel = await _urlRepository.GetById(id);

                await _cache.AddCacheAsync(cacheKey, urlModel);
            }

            return new UrlResponseModel(urlModel.OriginalUrl);
        }

        public async Task<UrlResponseModel> CreateShortenedUrl(UrlRequestModel request)
        {
            UrlModel urlModel = new(request.OriginalUrl, request.BaseUrl);
            int id = await _urlRepository.Add(urlModel);

            return new UrlResponseModel(request.OriginalUrl, request.BaseUrl, id);
        }
    }
}
