using AFDB.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.MembershipFees
{
    public class DeleteMembershipFeeModel : PageModel
    {
        private readonly IMembershipFeeRepository _membershipFeeRepository;

        public DeleteMembershipFeeModel(IMembershipFeeRepository membershipFeeRepository)
        {
            _membershipFeeRepository = membershipFeeRepository;
        }
        public IActionResult OnGet(int id)
        {
            try
            {
                _membershipFeeRepository.DeleteMembershipFee(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToPage("/MembershipFees/MembershipFees");
        }
    }
}
