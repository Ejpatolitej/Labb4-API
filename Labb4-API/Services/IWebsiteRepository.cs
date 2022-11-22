using Labb4_API.Models;

namespace Labb4_API.Services
{
    public interface IWebsiteRepository<T>
    {
        Task<T> AddLink(Website website);
        Task<T> GetWebsite(int id);
    }
}
