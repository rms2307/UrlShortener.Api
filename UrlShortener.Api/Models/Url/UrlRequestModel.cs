using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Api.Models.Url
{
    public class UrlRequestModel
    {
        [Required]
        public string OriginalUrl { get; set; }
        [Required]
        public string BaseUrl { get; set; }
    }
}
