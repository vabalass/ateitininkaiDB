using AFDB.Data;
using AFDB.Interfaces;
using AFDB.Models;
using AFDB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace AFDB.Pages.People
{
    public class EditPersonModel : PageModel
    {
        [BindProperty]
        public Person Person { get; set; }
        [BindProperty]
        public Pledge[] Pledges { get; set; }
        [BindProperty]
        public DateOnly[] PledgeDates { get; set; }
        private readonly IPeopleRepository _peopleRepository;
        private readonly IPledgeRepository _pledgeRepository;

        public EditPersonModel(IPeopleRepository peopleRepository, IPledgeRepository pledgeRepository)
        {
            _peopleRepository = peopleRepository;
            _pledgeRepository = pledgeRepository;
            PledgeDates = new DateOnly[4];
        }
        public ActionResult OnPostUpdatePerson()
        {
            for (int i = 0; i < 4; ++i)
            {
                var date = PledgeDates[i];
                var newPledge = new Pledge();
                newPledge.Date = date;

                if(date != DateOnly.MinValue)
                {
                    switch (i)
                    {
                        case 0:
                            newPledge.Association = "JAS";
                            break;
                        case 1:
                            newPledge.Association = "MAS";
                            break;
                        case 2:
                            newPledge.Association = "SAS";
                            break;
                        case 3:
                            newPledge.Association = "ASS";
                            break;
                    }
                    Person.Pledges.Add(newPledge);
                }
            }
            
            try
            {
                _peopleRepository.UpdatePerson(Person);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
            
            return RedirectToPage("/People/People");
        }
        public ActionResult OnPostDeletePerson()
        {
            try
            {
                _peopleRepository.DeletePerson(Person.Id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
            return RedirectToPage("/People/People");
        }
        public void OnGet(int id)
        {
            Person = _peopleRepository.GetPersonById(id);
            if(Person.Pledges != null) // If person doesnt have some kind of pledge, the field is populated with MinValue date
            {
                foreach (var pledge in Person.Pledges)
                {
                    switch (pledge.Association)
                    {
                        case "JAS":
                            PledgeDates[0] = pledge.Date;
                            break;

                        case "MAS":
                            PledgeDates[1] = pledge.Date;
                            break;

                        case "SAS":
                            PledgeDates[2] = pledge.Date;
                            break;

                        case "ASS":
                            PledgeDates[3] = pledge.Date;
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}
