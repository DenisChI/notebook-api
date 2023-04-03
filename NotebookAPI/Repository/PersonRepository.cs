using Microsoft.EntityFrameworkCore;
using Notebook.Data;
using Notebook.Models;

namespace Notebook.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly NotebookDbContext _context;

        public PersonRepository(NotebookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var persons = await _context.Persons.Include(x => x.Phones).ToListAsync();
            return persons;
        }

        public async Task<Person> GetAsync(int personId)
        {
            var person = await _context.Persons.Include(x => x.Phones).Where(x => x.PersonId == personId).FirstOrDefaultAsync();
            return person;
        }

        public async Task<int> AddAsync(Person newPerson)
        {
            _context.Persons.Add(newPerson);
            await _context.SaveChangesAsync();
            return newPerson.PersonId;
        }

        
        public async Task<Person> UpdateAsync(Person updatedPerson)
        {
            var person = await _context.Persons.Include(x => x.Phones).Where(x => x.PersonId == updatedPerson.PersonId).FirstOrDefaultAsync();
            if (person != null)
            {
                person.FirstName = updatedPerson.FirstName;
                person.LastName = updatedPerson.LastName;
                person.BirthYear = updatedPerson.BirthYear;
                person.Phones = updatedPerson.Phones;
                await _context.SaveChangesAsync();
            }
            return person;
        }

        public async Task<int> RemoveAsync(int personId)
        {
            var rowsAffected = await _context.Persons.Where(x => x.PersonId == personId).ExecuteDeleteAsync();
            return rowsAffected;
        }
    }
}
