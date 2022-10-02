using System.Threading.Tasks;
using UrlShortener.Api.Extensions;
using UrlShortener.Api.Infra.Data.Repositories.Interfaces;
using UrlShortener.Api.Models.Url;
using UrlShortener.Api.Services.Interfaces;

namespace UrlShortener.Api.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _urlRepository;

        public UrlService(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<UrlResponseModel> GetOriginalUrl(string suffixShortenedUrl)
        {
            // TODO: Add cache
            // TODO: Contagem de cliques
            var id = ShortUrlHelper.Decode(suffixShortenedUrl);

            UrlModel urlModel = await _urlRepository.GetById(id);

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
