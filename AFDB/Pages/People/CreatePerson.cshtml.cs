using AFDB.Interfaces;
using AFDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.People
{
    public class CreatePersonModel : PageModel
    {
        [BindProperty]
        public Person Person { get; set; }
        [BindProperty]
        public Pledge[] Pledges { get; set; }
        private readonly IPeopleRepository _peopleRepository;

        public CreatePersonModel(IPeopleRepository peopleRepository, IPledgeRepository pledgeRepository)
        {
            _peopleRepository = peopleRepository;
            Person = new Person();
            Pledges = new Pledge[4];
        }
        public ActionResult OnPost()
        {
            try
            {
                Pledges[0].Association = "JAS";
                Pledges[1].Association = "MAS";
                Pledges[2].Association = "SAS";
                Pledges[3].Association = "ASS";
                for (int i = 0; i < Pledges.Length; i++)
                {
                    if (Pledges[i].Date != DateOnly.MinValue)
                    {
                        Person.Pledges.Add(Pledges[i]);
                    }
                }
                _peopleRepository.AddPerson(Person);
                return RedirectToPage("/People/People");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
        public void OnGet()
        {
        }
    }
}
