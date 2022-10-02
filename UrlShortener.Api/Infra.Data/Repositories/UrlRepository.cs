using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UrlShortener.Api.Infra.Data.Context;
using UrlShortener.Api.Infra.Data.Repositories.Interfaces;
using UrlShortener.Api.Models.Url;

namespace UrlShortener.Api.Infra.Data.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ApplicationDbContext _context;

        public UrlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UrlModel> GetById(int id)
        {
            return await _context.UrlModels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Add(UrlModel url)
        {
            await _context.UrlModels.AddAsync(url);
            await _context.SaveChangesAsync();
            return url.Id;
        }
    }
}
