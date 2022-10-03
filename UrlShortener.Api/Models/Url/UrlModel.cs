namespace UrlShortener.Api.Models.Url
{
    public class UrlModel
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string BaseUrl { get; set; }

        public UrlModel() { }

        public UrlModel(int id, string originalUrl, string baseUrl)
        {
            Id = id;
            OriginalUrl = originalUrl;
            BaseUrl = baseUrl;
        }

        public UrlModel(string originalUrl, string baseUrl)
        {
            OriginalUrl = originalUrl;
            BaseUrl = baseUrl;
        }
    }
}
