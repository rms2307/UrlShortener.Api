using System.Threading.Tasks;
using UrlShortener.Api.Controllers.ApiModels;
using UrlShortener.Api.Extensions;
using UrlShortener.Api.Infra.Cache.Interfaces;
using UrlShortener.Api.Infra.Data.Repositories.Interfaces;
using UrlShortener.Api.Models.Url;
using UrlShortener.Api.Services.Interfaces;

namespace UrlShortener.Api.Services
{
    public class UrlService : IUrlService
    {

        private readonly IFeatureToggleService _featureToggleService;
        private readonly IUrlRepository _urlRepository;
        private readonly ICache<UrlModel> _cache;

        public UrlService(IUrlRepository urlRepository, ICache<UrlModel> cache, IFeatureToggleService featureToggleService)
        {
            _urlRepository = urlRepository;
            _cache = cache;
            _featureToggleService = featureToggleService;
        }

        public async Task<UrlResponseModel> GetOriginalUrlAsync(string suffixShortenedUrl)
        {
            var id = ShortUrlHelper.Decode(suffixShortenedUrl);

            UrlModel urlModel = null;
            var cacheKey = $"UrlModel:{id}-{suffixShortenedUrl}";

            var cacheEnabled = _featureToggleService.VerifyIfFeatureEnable("CacheEnabled");

            if (cacheEnabled)
                urlModel = await _cache.GetCacheAsync(cacheKey);

            if (urlModel is null)
            {
                urlModel = await _urlRepository.GetById(id);

                if (cacheEnabled)
                    await _cache.AddCacheAsync(cacheKey, urlModel);
            }

            return new UrlResponseModel(urlModel.OriginalUrl);
        }

        public async Task<UrlResponseModel> CreateShortenedUrlAsync(UrlRequestModel request)
        {
            UrlModel urlModel = new(request.OriginalUrl, request.BaseUrl);
            int id = await _urlRepository.Add(urlModel);

            return new UrlResponseModel(request.OriginalUrl, request.BaseUrl, id);
        }
    }
}
