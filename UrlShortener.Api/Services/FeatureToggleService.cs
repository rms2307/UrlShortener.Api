using UrlShortener.Api.Infra.Cache.Interfaces;
using UrlShortener.Api.Infra.Data.Repositories.Interfaces;
using UrlShortener.Api.Models.Url;
using UrlShortener.Api.Services.Interfaces;

namespace UrlShortener.Api.Services
{
    public class FeatureToggleService : IFeatureToggleService
    {
        private readonly IFeatureToggleRepository _repository;

        public FeatureToggleService(IFeatureToggleRepository repository)
            => _repository = repository;

        public bool VerifyIfFeatureEnable(string name)
        {
            var featureToggle = _repository.GetFeatureToggle(name).Result;
            if (featureToggle is null)
                return false;

            return featureToggle.Status;
        }
    }
}
