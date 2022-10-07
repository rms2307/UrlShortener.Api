using System.Threading.Tasks;
using UrlShortener.Api.Models;

namespace UrlShortener.Api.Infra.Data.Repositories.Interfaces
{
    public interface IFeatureToggleRepository
    {
        Task<FeatureToggle> GetFeatureToggle(string name);
    }
}
