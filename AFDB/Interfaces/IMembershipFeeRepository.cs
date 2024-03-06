using AFDB.Models;

namespace AFDB.Interfaces
{
    public interface IMembershipFeeRepository
    {
        IEnumerable<Membershipfee> GetAllMembershipFees();
        IEnumerable<Membershipfeefull> GetAllMembershipFeesFull();
        Membershipfee? GetMembershipFeeById(int membershipFeeId);
        void AddMembershipFee(Membershipfee membershipfee);
        void AddMembershipFees(IEnumerable<Membershipfee> membershipfees);
        //void UpdateMembershipFee(Membershipfee membershipfee);
        void DeleteMembershipFee(int membershipFeeId);
    }
}
