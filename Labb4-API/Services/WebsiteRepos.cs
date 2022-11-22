using Labb4_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4_API.Services
{
    public class WebsiteRepos : IWebsiteRepository<Website>
    {
        private AppDbContext _context;
        public WebsiteRepos(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Website> AddLink(Website website)
        {
            var result = await _context.Websites.AddAsync(website);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Website> GetWebsite(int id)
        {
            return await _context.Websites.Include(p => p.Persons.Website)
                .FirstOrDefaultAsync(w => w.WebsiteID == id);
        }
    }
}
