using AFDB.Interfaces;
using AFDB.Models;

namespace AFDB.Repositories
{
    public class PledgeRepository : IPledgeRepository
    {
        private readonly AteitininkaiDbContext _context;
        public PledgeRepository(AteitininkaiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pledge> GetAllPledges()
        {
            return _context.Pledges.ToList();
        }

        public void AddPledgeWithPerson(Pledge pledge, Person person)
        {
            pledge.Personid = person.Id;
            _context.Pledges.Add(pledge);
            _context.SaveChanges();
        }

        public void AddPledge(Pledge pledge)
        {
            _context.Pledges.Add(pledge);
        }
    }
}
