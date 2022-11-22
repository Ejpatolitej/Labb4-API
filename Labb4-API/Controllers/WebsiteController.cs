using Labb4_API.Models;
using Labb4_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsiteController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebsiteRepository<Website> _websiteRepo;

        public WebsiteController(AppDbContext context, IWebsiteRepository<Website> websiteRepo)
        {
            _context = context;
            _websiteRepo = websiteRepo;
        }

        //GET WEBSITE
        [HttpGet("{id}")]
        public async Task<ActionResult<Website>> GetWebsite(int id)
        {
            var result = await _websiteRepo.GetWebsite(id);
            if (result != null)
            {
                return result;
            }
            return NotFound();
        }

        //ADD WEBSITE
        [HttpPost]
        [Route("{id}")]
        public async Task<ActionResult<Website>> Add(Website website)
        {
            if (website != null)
            {
                var createdEntity = await _websiteRepo.AddLink(website);
                return CreatedAtAction(nameof(GetWebsite), new { id = createdEntity.WebsiteID }, createdEntity);
            }

            return BadRequest();
        }

        //ADD WEBSITE
        [HttpPost]
        public async Task<Website> AddWebsite(Website website, int personId, int interestId)
        {
            var result = await _context.Websites.AddAsync(new Website { PersonID = personId, InterestID = interestId});
            await _context.SaveChangesAsync();
            return result.Entity;
        }

    }
}
