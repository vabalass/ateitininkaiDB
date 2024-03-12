using afdb.Services;
using AFDB.Data;
using AFDB.Interfaces;
using AFDB.Models;
using AFDB.OthetModels;
using AFDB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.People
{
    public class PeopleModel : PageModel
    {
        public IPeopleRepository peopleRepository;
        private readonly IServiceCSV _serviceCSV;
        public IEnumerable<PersonFull> PeopleFull;
        private readonly PersonSimpleService _personSimpleService;
        [BindProperty]
        public SearchFilters Filter { get; set; }

        public PeopleModel(IPeopleRepository pr, IServiceCSV serviceCSV)
        {
            peopleRepository = pr;
            _personSimpleService = new PersonSimpleService();
            PeopleFull = peopleRepository.GetAllFullPeople();
            _serviceCSV = serviceCSV;
            Filter = new SearchFilters();
        }
        public ActionResult OnPostDownloadFile()
        {
            var filteredPeople = PeopleStorage.GetPeopleFull();
            if(filteredPeople != null)
            {
                return (ActionResult)_serviceCSV.DownloadPeopleFullCSV(filteredPeople);
            }
            else
            {
                return (ActionResult)_serviceCSV.DownloadPeopleFullCSV(PeopleFull);
            }
        }
        public void OnPostFilterFees()
        {
            var after = _personSimpleService.Filter(PeopleFull, Filter);
            PeopleFull = after;
            PeopleStorage.SetPeopleFull(PeopleFull);
        }
        public void OnGet()
        {
        }
    }
}
