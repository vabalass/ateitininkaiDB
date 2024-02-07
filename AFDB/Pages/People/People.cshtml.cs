using AFDB.Data;
using AFDB.Interfaces;
using AFDB.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.People
{
    public class PeopleModel : PageModel
    {
        public IPeopleRepository peopleRepository;

        public PeopleModel(IPeopleRepository pr)
        {
            peopleRepository = pr;
        }
        public void OnGet()
        {
        }
    }
}
