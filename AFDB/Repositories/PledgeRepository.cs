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

        public void AddPledge(Pledge pledge)
        {
            _context.Pledges.Add(pledge);
        }
    }
}
