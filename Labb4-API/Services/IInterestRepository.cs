using Labb4_API.Models;

namespace Labb4_API.Services
{
    public interface IInterestRepository<T>
    {
        Task<T> addInterest(Interest interest);

        Task<T> GetInterest(int id);
    }
}
