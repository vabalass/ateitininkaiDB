using AFDB.Models;

namespace AFDB.Data
{
    public static class MembershipFeesStorage
    {
        private static IEnumerable<Membershipfeefull>? _membershipFees;

        public static IEnumerable<Membershipfeefull> GetMembershipFees()
        {
            return _membershipFees;
        }

        public static void SetMembershipFees(IEnumerable<Membershipfeefull> membershipFees)
        {
            _membershipFees = membershipFees;
        }
    }
}
