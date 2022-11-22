using Labb4_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4_API.Services
{
    public class PersonRepos : IPersonRepository<Person>
    {
        private AppDbContext _dbContext;
        public PersonRepos(AppDbContext context)
        {
            _dbContext = context;
        }


        public async Task<IEnumerable<Person>> GetInterests(int id)
        {
            return await _dbContext.people
                .Include(i => i.Interests)
                .Where(p => p.PersonID == id).ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetLinks(int id)
        {
            return await _dbContext.people
                .Include(p => p.Interests)
                .ThenInclude(w => w.Websites)
                .Where(p => p.PersonID == id).ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            return await _dbContext.people.ToListAsync();
        }
    }
}
