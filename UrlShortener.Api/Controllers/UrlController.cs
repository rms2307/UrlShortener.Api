using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using UrlShortener.Api.Models.Url;
using UrlShortener.Api.Services.Interfaces;

namespace UrlShortener.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly ILogger<UrlController> _logger;
        private readonly IUrlService _urlService;

        public UrlController(ILogger<UrlController> logger, IUrlService urlService)
        {
            _logger = logger;
            _urlService = urlService;
        }

        [HttpGet("{suffixShortenedUrl}/decode")]
        [SwaggerOperation(Summary = "Endpoint responsavel por devolver a URL original.")]
        [ProducesResponseType(typeof(UrlResponseModel), StatusCodes.Status200OK )]
        public async Task<ActionResult<UrlResponseModel>> GetOriginalUrl([FromRoute] string suffixShortenedUrl)
        {
            return Ok(await _urlService.GetOriginalUrl(suffixShortenedUrl));
        }

        [HttpPost("encode")]
        [SwaggerOperation(Summary = "Endpoint responsavel por devolver uma URL encurtada.")]
        [ProducesResponseType(typeof(UrlResponseModel), StatusCodes.Status201Created)]
        public async Task<ActionResult<UrlResponseModel>> CreateShortenedUrl([FromBody] UrlRequestModel request)
        {
            return Created(string.Empty, await _urlService.CreateShortenedUrl(request));
        }
    }
}
