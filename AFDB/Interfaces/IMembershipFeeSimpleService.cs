using AFDB.Models;
using AFDB.OthetModels;

namespace AFDB.Interfaces
{
    public interface IMembershipFeeSimpleService
    {
        IEnumerable<Membershipfee> convertFromFullToDefault(IEnumerable<Membershipfeefull> feesFull);
        IEnumerable<Membershipfeefull> RemoveFeesWithoutPersonId(IEnumerable<Membershipfeefull> Fees);
        IEnumerable<Membershipfeefull> Filter(IEnumerable<Membershipfeefull> fees, SearchFilters searchFilters);
    }
}
