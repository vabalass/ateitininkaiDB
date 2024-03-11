using AFDB.Interfaces;
using AFDB.Models;
using AFDB.OthetModels;
using NuGet.Protocol.Core.Types;

namespace AFDB.Services
{
    public class MembershipFeeSimpleService : IMembershipFeeSimpleService
    {
        public IEnumerable<Membershipfee> convertFromFullToDefault(IEnumerable<Membershipfeefull> feesFull)
        {
            var fees = new List<Membershipfee>();

            foreach (var feeFull in feesFull)
            {
                var fee = new Membershipfee
                {
                    Personid = feeFull.Personid ?? 0, // Use 0 if Personid is null
                    Amount = feeFull.Amount ?? 0, // Use 0 if Amount is null
                    Paymentdate = feeFull.Paymentdate ?? default, // Use default value if Paymentdate is null
                    Description = feeFull.Description
                };

                fees.Add(fee);
            }

            return fees;
        }

        public IEnumerable<Membershipfeefull> RemoveFeesWithoutPersonId(IEnumerable<Membershipfeefull> Fees)
        {
            var filteredFees = Fees.Where(record => record.Personid != null);

            return filteredFees;
        }

        public IEnumerable<Membershipfeefull> Filter(IEnumerable<Membershipfeefull> fees, SearchFilters searchFilters)
        {
            if (searchFilters == null)
            {
                return fees;
            }

            if (searchFilters.DateFrom == default && searchFilters.DateTo == default)
            {
                return fees; // No date range selected, return the original list
            }

            return fees.Where(fee =>
                (string.IsNullOrEmpty(searchFilters.SearchField) ||
                    fee.Personfirstname?.Contains(searchFilters.SearchField, StringComparison.OrdinalIgnoreCase) == true ||
                    fee.Personlastname?.Contains(searchFilters.SearchField, StringComparison.OrdinalIgnoreCase) == true ||
                    fee.Description?.Contains(searchFilters.SearchField, StringComparison.OrdinalIgnoreCase) == true ||
                    fee.Personid.ToString()?.Contains(searchFilters.SearchField, StringComparison.OrdinalIgnoreCase) == true ||
                    fee.Paymentid.ToString()?.Contains(searchFilters.SearchField, StringComparison.OrdinalIgnoreCase) == true ||
                    (fee.Amount.HasValue && fee.Amount.Value.ToString().Contains(searchFilters.SearchField, StringComparison.OrdinalIgnoreCase) == true)) &&
                (string.IsNullOrEmpty(searchFilters.MembershipStatus) || fee.Membershipstatus == searchFilters.MembershipStatus) &&
                (fee.Paymentdate >= searchFilters.DateFrom) &&
                (fee.Paymentdate <= searchFilters.DateTo)
            );
        }
    }
}
