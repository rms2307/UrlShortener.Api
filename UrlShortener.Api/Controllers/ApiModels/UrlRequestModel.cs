using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Api.Controllers.ApiModels
{
    public class UrlRequestModel
    {
        [Required]
        public string OriginalUrl { get; set; }
        [Required]
        public string BaseUrl { get; set; }
    }
}
