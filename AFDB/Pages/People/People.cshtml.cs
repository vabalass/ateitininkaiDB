using AFDB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.People
{
    public class PeopleModel : PageModel
    {
        public AteitininkaiDbContext _context { get; set; }

        public PeopleModel(AteitininkaiDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
    }
}
