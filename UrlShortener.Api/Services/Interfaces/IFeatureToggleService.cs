namespace UrlShortener.Api.Services.Interfaces
{
    public interface IFeatureToggleService
    {
        bool VerifyIfFeatureEnable(string name);
    }
}
