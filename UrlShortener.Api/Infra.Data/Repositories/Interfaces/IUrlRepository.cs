using System.Threading.Tasks;
using UrlShortener.Api.Models.Url;

namespace UrlShortener.Api.Infra.Data.Repositories.Interfaces
{
    public interface IUrlRepository
    {
        Task<UrlModel> GetById(int id);
        Task<int> Add(UrlModel url);
    }
}
