using AFDB.Data;
using AFDB.Interfaces;
using AFDB.Models;

namespace AFDB.Repositories
{
    public class MembershipFeeRepository : IMembershipFeeRepository
    {
        private readonly AteitininkaiDbContext _context;
        public MembershipFeeRepository(AteitininkaiDbContext context)
        {
            _context = context;
        }

        public void AddMembershipFee(Membershipfee membershipfee)
        {
            _context.Membershipfees.Add(membershipfee);
            _context.SaveChanges();
        }

        public void AddMembershipFees(IEnumerable<Membershipfee> membershipfees)
        {
            _context.Membershipfees.AddRange(membershipfees);
            _context.SaveChanges();
        }

        public void DeleteMembershipFee(int membershipFeeId)
        {
            var membershipFee = _context.Membershipfees.Find(membershipFeeId);
            if(membershipFee != null)
            {
                _context.Membershipfees.Remove(membershipFee);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Membershipfee> GetAllMembershipFees()
        {
            return _context.Membershipfees.ToList();
        }

        public IEnumerable<Membershipfeefull> GetAllMembershipFeesFull()
        {
            return _context.Membershipfeefulls.ToList();
        }

        public Membershipfee? GetMembershipFeeById(int membershipFeeId)
        {
            var membershipFee = _context.Membershipfees.Find(membershipFeeId);
            if(membershipFee != null)
            {
                return membershipFee;
            }
            return null;
        }
    }
}
