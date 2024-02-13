using AFDB.Interfaces;
using AFDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.Tables
{
    public class _PeopleTablesModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Person> People { get; set; }
        public _PeopleTablesModel(IPeopleRepository peopleRepository)
        {
            People = peopleRepository.GetAllPeople();
        }
        public void OnGet()
        {
        }
    }
}
