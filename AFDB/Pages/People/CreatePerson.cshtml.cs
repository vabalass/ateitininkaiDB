using AFDB.Interfaces;
using AFDB.Models;
using AFDB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace AFDB.Pages.People
{
    public class CreatePersonModel : PageModel
    {
        [BindProperty]
        public Person Person { get; set; }
        [BindProperty]
        public Pledge Pledge { get; set; }
        [BindProperty]
        public bool HasPledge { get; set; }
        private readonly IPeopleRepository _peopleRepository;
        private readonly IPledgeRepository _pledgeRepository;

        public CreatePersonModel(IPeopleRepository peopleRepository, IPledgeRepository pledgeRepository)
        {
            _peopleRepository = peopleRepository;
            _pledgeRepository = pledgeRepository;
            Person = new Person();
            Pledge = new Pledge();
            HasPledge = false;
        }
        public RedirectToPageResult OnPost()
        {
            _peopleRepository.AddPerson(Person);
            if(HasPledge && Pledge.Association != null)
            {
                _pledgeRepository.AddPledgeWithPerson(Pledge, Person);
                Console.WriteLine("PledgeAdded!");
            }
            return RedirectToPage("/People/People");
        }
        public void OnGet()
        {
        }
    }
}
