using AFDB.Interfaces;
using AFDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.People
{
    public class PeopleModel : PageModel
    {
        public IPeopleRepository peopleRepository;
        private readonly IDownloadCSV _downloadCSV;

        public PeopleModel(IPeopleRepository pr, IDownloadCSV downloadCSV)
        {
            peopleRepository = pr;
            _downloadCSV = downloadCSV;
        }
        public ActionResult OnPostDownloadFile()
        {
            var people = peopleRepository.GetAllPeople();
            return (ActionResult)_downloadCSV.DownloadPeopleCSV(people);
        }
        public void OnGet()
        {
        }
    }
}
