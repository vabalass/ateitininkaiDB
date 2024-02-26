using AFDB.Interfaces;
using AFDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AFDB.Pages.Tables
{
    public class _AddPeopleTableModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Person>? _People { get; set; }
        public _AddPeopleTableModel(IEnumerable<Person> people)
        {
            if(people != null)
            { 
                _People = people;
            }
            else
            {
                _People = new List<Person>();
            }
        }
        public void OnGet()
        {
        }
    }
}
