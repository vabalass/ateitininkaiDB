using AFDB.Interfaces;
using AFDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.People
{
    public class PeopleModel : PageModel
    {
        public IPeopleRepository peopleRepository;
        private readonly IServiceCSV _serviceCSV;
        public IEnumerable<PersonFull> PeopleFull;

        public PeopleModel(IPeopleRepository pr, IServiceCSV serviceCSV)
        {
            peopleRepository = pr;
            PeopleFull = peopleRepository.GetAllFullPeople();
            _serviceCSV = serviceCSV;
        }
        public ActionResult OnPostDownloadFile()
        {
            return (ActionResult)_serviceCSV.DownloadPeopleFullCSV(PeopleFull);
        }
        public void OnGet()
        {
        }
    }
}
