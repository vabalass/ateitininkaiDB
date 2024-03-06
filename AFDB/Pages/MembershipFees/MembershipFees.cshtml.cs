using AFDB.Interfaces;
using AFDB.Models;
using AFDB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.MembershipFees
{
    public class MembershipFeesModel : PageModel
    {
        private readonly IMembershipFeeRepository _membershipFeeRepository;
        public IEnumerable<Membershipfeefull> Membershipfeesfull;
        public MembershipFeesModel(IMembershipFeeRepository membershipFeeRepository)
        {
            _membershipFeeRepository = membershipFeeRepository;
            Membershipfeesfull = _membershipFeeRepository.GetAllMembershipFeesFull();
        }
        public void OnGet()
        {
        }
    }
}
