namespace Labb4_API.Services
{
    public interface IPersonRepository<T>
    {
        Task<IEnumerable<T>> GetPeople();

        Task<IEnumerable<T>> GetInterests(int id);

        Task<IEnumerable<T>> GetLinks(int id);
    }
}
