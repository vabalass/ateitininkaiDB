using AFDB.Interfaces;
using AFDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AFDB.Pages.Tables
{
    public class _PeopleFullTableModel : PageModel
    {
        [BindProperty]
        public IEnumerable<PersonFull>? _PeopleFull { get; set; }
        public _PeopleFullTableModel(IEnumerable<PersonFull> peopleFull)
        {
            if(peopleFull != null)
            { 
                _PeopleFull = peopleFull;
            }
            else
            {
                _PeopleFull = new List<PersonFull>();
            }
        }
        public void OnGet()
        {
        }
    }
}
