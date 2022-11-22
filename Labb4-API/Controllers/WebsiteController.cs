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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Website>> GetWebsite(int id)
        {
            var result = await _websiteRepo.GetWebsite(id);
            if (result != null)
            {
                return result;
            }
            return NotFound();
        }

        //UPDATE WEBSITE
        [HttpPost]
        public async Task<ActionResult<Website>> Add(Website website)
        {
            if (website != null)
            {
                var createdEntity = await _websiteRepo.AddLink(website);
                return CreatedAtAction(nameof(GetWebsite), new { id = createdEntity.WebsiteID }, createdEntity);
            }

            return BadRequest();
        }
    }
}
