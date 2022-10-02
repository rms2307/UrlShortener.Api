using UrlShortener.Api.Extensions;

namespace UrlShortener.Api.Models.Url
{
    public class UrlResponseModel
    {
        public string UrlOriginal { get; private set; } = string.Empty;
        public string UrlShortener { get; private set; } = string.Empty;

        public UrlResponseModel(string urlOriginal, string baseUrl, int id)
        {
            UrlOriginal = urlOriginal;
            UrlShortener = MountShortenedUrl(baseUrl, id);
        }

        public UrlResponseModel(string urlOriginal)
        {
            UrlOriginal = urlOriginal;
        }

        private static string MountShortenedUrl(string baseUrl, int id)
        {
            baseUrl = baseUrl.Substring(baseUrl.Length - 1) != "/"
                ? baseUrl
                : baseUrl.Remove(baseUrl.Length - 1);

            return $"{baseUrl}/{ShortUrlHelper.Encode(id)}";
        }
    }
}
