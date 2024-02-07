using AFDB.Data;
using AFDB.Interfaces;
using AFDB.Models;
using Microsoft.EntityFrameworkCore;

namespace AFDB.Repositories
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
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int id = person.Id;
                    _context.Entry(person).State = EntityState.Modified;
                    _context.SaveChanges();

                    var personFromDb = GetPersonById(id);
                    personFromDb.Registrationdate = DateTime.Now;
                    _context.Entry(personFromDb).State = EntityState.Modified;
                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw;
                }
            }
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
