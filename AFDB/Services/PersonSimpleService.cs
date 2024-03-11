using AFDB.Models;
using AFDB.OthetModels;

namespace afdb.Services
{
    public class PersonSimpleService
    {
        public IEnumerable<PersonFull> Filter(IEnumerable<PersonFull> people, SearchFilters searchFilters)
        {
            if (searchFilters == null)
            {
                return people;
            }

            return people.Where(fee =>
                (string.IsNullOrEmpty(searchFilters.SearchField) ||
                    fee.Firstname?.Contains(searchFilters.SearchField, StringComparison.OrdinalIgnoreCase) == true ||
                    fee.Lastname?.Contains(searchFilters.SearchField, StringComparison.OrdinalIgnoreCase) == true ||
                    fee.Gender?.Contains(searchFilters.SearchField, StringComparison.OrdinalIgnoreCase) == true ||
                    fee.Address?.Contains(searchFilters.SearchField, StringComparison.OrdinalIgnoreCase) == true ||
                    fee.Description?.Contains(searchFilters.SearchField, StringComparison.OrdinalIgnoreCase) == true ||
                    fee.Id.ToString()?.Contains(searchFilters.SearchField, StringComparison.OrdinalIgnoreCase) == true ||
                    fee.Age.ToString()?.Contains(searchFilters.SearchField, StringComparison.OrdinalIgnoreCase) == true) && // <-- Corrected closing parenthesis
                (string.IsNullOrEmpty(searchFilters.MembershipStatus) || fee.Membershipstatus == searchFilters.MembershipStatus) &&
                (fee.Birthdate >= searchFilters.DateFrom) &&
                (fee.Birthdate <= searchFilters.DateTo)
            );
        }
    }
}
