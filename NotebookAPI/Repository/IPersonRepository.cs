using Notebook.Models;

namespace Notebook.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> GetAsync(int personId);
        Task<int> AddAsync(Person newPerson);
        Task<Person> UpdateAsync(Person updatedPerson);
        Task<int> RemoveAsync(int personId);
    }
}
