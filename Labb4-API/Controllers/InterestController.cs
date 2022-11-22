using Labb4_API.Models;
using Labb4_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IInterestRepository<Interest> _interestRepo;
        public InterestController(AppDbContext context, IInterestRepository<Interest> interestRepo)
        {
            _context = context;
            _interestRepo = interestRepo;
        }

        //GET INTERESTS
        [HttpGet("{id}")]
        public async Task<ActionResult<Interest>> GetInterest(int id)
        {
            var result = await _interestRepo.GetInterest(id);
            if (result != null)
            {
                return result;
            }
            return NotFound();
        }

        //UPDATE INTERESTS
        [HttpPut("{id}")]
        public async Task<ActionResult<Interest>> updateInterest(int id, Interest update)
        {
            var websiteToUpdate = await _interestRepo.GetInterest(id);

            if (websiteToUpdate == null)
            {
                return NotFound();
            }
            return await _interestRepo.addInterest(update);
        }
    }
}
