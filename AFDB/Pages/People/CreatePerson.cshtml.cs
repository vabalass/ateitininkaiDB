using AFDB.Interfaces;
using AFDB.Models;
using AFDB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.People
{
    public class CreatePersonModel : PageModel
    {
        [BindProperty]
        public Person Person { get; set; }
        private readonly IPeopleRepository _peopleRepository;

        public CreatePersonModel(IPeopleRepository peopleRepository) 
        {
            _peopleRepository = peopleRepository;
            Person = new Person();
        }
        public RedirectToPageResult OnPost()
        {
            _peopleRepository.AddPerson(Person);
            return RedirectToPage("/People/People");
        }
        public void OnGet()
        {
        }
    }
}
