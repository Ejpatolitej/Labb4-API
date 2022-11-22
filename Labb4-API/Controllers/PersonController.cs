using Labb4_API.Models;
using Labb4_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPersonRepository<Person> _personRepo;

        public PersonController(AppDbContext context, IPersonRepository<Person> personRepo)
        {
            _context = context;
            _personRepo = personRepo;
        }

        //GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _context.people.ToListAsync();
        }

        //GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.people.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        //ADD
        [HttpPost]
        public async Task<Person> AddPerson(Person person)
        {
            var result = await _context.people.AddAsync(person);
            await _context.SaveChangesAsync();
            return result.Entity;
        }


        //UPDATE
        [HttpPut("{id}")]
        public async Task<Person> Update(Person Entity)
        {
            var result = await _context.people.FirstOrDefaultAsync(p => p.PersonID == Entity.PersonID);
            if (result != null)
            {
                result.FirstName = Entity.FirstName;
                result.LastName = Entity.LastName;
                result.Phone = Entity.Phone;

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<Person> Delete(int id)
        {
            var result = await _context.people.FirstOrDefaultAsync(p => p.PersonID == id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        //GET INTERESTS
        [HttpGet]
        [Route("{id}/interest")]
        public async Task<ActionResult<Person>> GetInterests(int id)
        {
            var result = await _personRepo.GetInterests(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        //GET LINKS
        [HttpGet]
        [Route("{id}/link")]
        public async Task<ActionResult<Person>> GetLinks(int id)
        {
            var result = await _personRepo.GetLinks(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
