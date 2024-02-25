using AFDB.Interfaces;
using AFDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AFDB.Pages.Tables
{
    public class _PeopleTablesModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Person>? _People { get; set; }
        public _PeopleTablesModel(IEnumerable<Person> people)
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
