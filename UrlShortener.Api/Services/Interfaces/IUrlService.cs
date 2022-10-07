using System.Threading.Tasks;
using UrlShortener.Api.Controllers.ApiModels;

namespace UrlShortener.Api.Services.Interfaces
{
    public interface IUrlService
    {
        Task<UrlResponseModel> GetOriginalUrlAsync(string suffixShortenedUrl);
        Task<UrlResponseModel> CreateShortenedUrlAsync(UrlRequestModel request);
    }
}
