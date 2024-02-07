using AFDB.Data;
using AFDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.Tables
{
    public class _PeopleTablesModel : PageModel
    {
        private readonly AteitininkaiDbContext _context;
        [BindProperty]
        public IEnumerable<Person> People { get; set; }
        public _PeopleTablesModel(AteitininkaiDbContext context)
        {
            _context = context;
            People = context.People.ToList();
        }
        public void OnGet()
        {
        }
    }
}
