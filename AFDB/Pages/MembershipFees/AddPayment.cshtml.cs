using AFDB.Interfaces;
using AFDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.WebSockets;

namespace AFDB.Pages.MembershipFees
{
    public class AddPaymentModel : PageModel
    {
        [BindProperty]
        public Membershipfee Fee { get; set; }
        [BindProperty]
        public IEnumerable<Person> People { get; set; }
        private readonly IMembershipFeeRepository _membershipFeeRepository;
        private readonly IPeopleRepository _peopleRepository;

        public AddPaymentModel(IMembershipFeeRepository membershipFeeRepository, IPeopleRepository peopleRepository)
        {
            _membershipFeeRepository = membershipFeeRepository;
            _peopleRepository = peopleRepository;
            Fee = new Membershipfee();
            People = _peopleRepository.GetAllPeople();
        }
        public ActionResult OnPost()
        {
            try
            { 
                _membershipFeeRepository.AddMembershipFee(Fee);
                return RedirectToPage("/MembershipFees/MembershipFees");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.ToString());
                return Page();
            }
        }

        public void OnGet()
        {
        }
    }
}
