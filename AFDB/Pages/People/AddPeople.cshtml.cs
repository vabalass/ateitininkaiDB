using AFDB.Data;
using AFDB.Interfaces;
using AFDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFDB.Pages.People
{
    public class AddPeopleModel : PageModel
    {
        private readonly IServiceCSV _serviceCSV;
        private readonly IPeopleRepository _peopleRepository;
        public IEnumerable<Person> People;
        [BindProperty]
        public IFormFile CsvFile { get; set; }
        public AddPeopleModel(IServiceCSV serviceCSV, IPeopleRepository peopleRepository) 
        {
            _serviceCSV = serviceCSV;
            _peopleRepository = peopleRepository;
        }

        public ActionResult OnPostDownloadExample()
        {
            //return random people 3 people list
            return (ActionResult)_serviceCSV.DownloadPeopleCSV(_serviceCSV.generateRandomPeopleList(3), false);
        }

        public ActionResult OnPostAddPeopleToDB() 
        {
            People = PeopleStorage.GetPeople();
            if (People != null && People.Any())
            {
                try
                {
                    _peopleRepository.AddPeople(People);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return RedirectToPage("/People/People");
            }
            else
            {
                return Page();
            }

        }

        public IActionResult OnPostReadFile()
        {
            if(CsvFile != null)
            {
                People = _serviceCSV.ReadPeopleCSV(CsvFile.OpenReadStream(), false);
            }

            PeopleStorage.SetPeople(People);
            return Page();
        }

        public void OnGet()
        {

        }
    }
}
