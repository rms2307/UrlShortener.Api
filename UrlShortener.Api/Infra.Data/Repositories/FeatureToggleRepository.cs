using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UrlShortener.Api.Infra.Data.Context;
using UrlShortener.Api.Infra.Data.Repositories.Interfaces;
using UrlShortener.Api.Models;

namespace UrlShortener.Api.Infra.Data.Repositories
{
    public class FeatureToggleRepository : IFeatureToggleRepository
    {
        private readonly ApplicationDbContext _context;

        public FeatureToggleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FeatureToggle> GetFeatureToggle(string name)
           => await _context.FeatureToggles.FirstOrDefaultAsync(x => x.Name == name);
    }
}
