using AFDB.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.People
{
    public class PeopleModel : PageModel
    {
        public IPeopleRepository peopleRepository;
        private readonly IServiceCSV _serviceCSV;

        public PeopleModel(IPeopleRepository pr, IServiceCSV serviceCSV)
        {
            peopleRepository = pr;
            _serviceCSV = serviceCSV;
        }
        public ActionResult OnPostDownloadFile()
        {
            var people = peopleRepository.GetAllPeople();
            return (ActionResult)_serviceCSV.DownloadPeopleCSV(people, true);
        }
        public void OnGet()
        {
        }
    }
}
