using ateitiesDB.Models;

namespace ateitiesDB.Repositories
{
    public class UnitsRepository
    {
        private readonly AteitininkaiDbContext _context;
        public UnitsRepository(AteitininkaiDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Person> GetAllPeople()
        {
            return _context.People.ToList();
        }
    }
}
