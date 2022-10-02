using System.Threading.Tasks;
using UrlShortener.Api.Models.Url;

namespace UrlShortener.Api.Services.Interfaces
{
    public interface IUrlService
    {
        Task<UrlResponseModel> GetOriginalUrl(string suffixShortenedUrl);
        Task<UrlResponseModel> CreateShortenedUrl(UrlRequestModel request);
    }
}
