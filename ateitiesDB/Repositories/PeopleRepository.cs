using ateitiesDB.Interfaces;
using ateitiesDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ateitiesDB.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AteitininkaiDbContext _context;
        public PeopleRepository(AteitininkaiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _context.People.ToList();
        }

        public Person GetPersonById(int personId)
        {
            var person = _context.People.Find(personId);
            if (person != null)
            {
                return person;
            }
            else
            {
                return null;
            }
        }

        public void AddPerson(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletePerson(int personId)
        {
            var person = _context.People.Find(personId);
            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChangesAsync();
            }
        }
    }
}
