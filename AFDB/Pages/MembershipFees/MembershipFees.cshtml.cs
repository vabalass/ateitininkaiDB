using AFDB.Interfaces;
using AFDB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.MembershipFees
{
    public class MembershipFeesModel : PageModel
    {
        private readonly IMembershipFeeRepository _membershipFeeRepository;
        public MembershipFeesModel(IMembershipFeeRepository membershipFeeRepository)
        {
            _membershipFeeRepository = membershipFeeRepository;
        }
        public void OnGet()
        {
            var membershipFees = _membershipFeeRepository.GetAllMembershipFees();
            foreach(var membership in membershipFees)
            {
                ModelPrinter.PrintMembershipFee(membership);
            }
        }
    }
}
