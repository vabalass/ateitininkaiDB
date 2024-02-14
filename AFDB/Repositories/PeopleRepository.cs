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
            var Person = _context.People
                      .Include(p => p.Attendsevents)
                      .Include(p => p.Belongstounits)
                      .Include(p => p.Pledges)
                      .Where(p => p.Id == personId)
                      .FirstOrDefault();
            if (Person != null)
            {
                return Person;
            }
            else
            {
                return null;
            }
        }

        public Person AddPerson(Person Person)
        {
            _context.People.Add(Person);
            _context.SaveChanges();
            return Person;
        }

        public void UpdatePerson(Person Person)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int id = Person.Id;
                    _context.Entry(Person).State = EntityState.Modified;
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
            var Person = _context.People.Find(personId);
            if (Person != null)
            {
                _context.People.Remove(Person);
                _context.SaveChangesAsync();
            }
        }
    }
}
