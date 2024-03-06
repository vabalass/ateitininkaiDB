using AFDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.Tables
{
    public class _MembershipFeesFullTableModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Membershipfeefull>? _membershipfeefulls {  get; set; }
        public _MembershipFeesFullTableModel(IEnumerable<Membershipfeefull> membershipfeefulls) 
        {
            if (membershipfeefulls != null)
            {
                _membershipfeefulls = membershipfeefulls;
            }
            else
            {
                _membershipfeefulls = new List<Membershipfeefull>();
            }
        }

        public void OnGet()
        {
        }
    }
}
