using AFDB.Interfaces;
using AFDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AFDB.Pages.Tables
{
    public class _AddFeesTableModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Membershipfeefull>? _Fees { get; set; }
        public _AddFeesTableModel(IEnumerable<Membershipfeefull> fees)
        {
            if(fees != null)
            {
                _Fees = fees;
            }
            else
            {
                _Fees = new List<Membershipfeefull>();
            }
        }
        public void OnGet()
        {
        }
    }
}
