using Labb4_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4_API.Services
{
    public class InterestRepos : IInterestRepository<Interest>
    {
        private AppDbContext _context;
        public InterestRepos(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Interest> addInterest(Interest interest)
        {
            var result = await _context.Interests.FirstOrDefaultAsync(i => i.InterestID == interest.InterestID);
            if (result != null)
            {
                result.InterestTitle = interest.InterestTitle;
                result.InterestDescript = interest.InterestDescript;

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Interest> GetInterest(int id)
        {
            return await _context.Interests.FirstOrDefaultAsync(i => i.InterestID == id);
        }
    }
}
