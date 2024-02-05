using ateitiesDB.Interfaces;
using ateitiesDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ateitiesDB.ControllersView
{
    public class AsmenysController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;

        public AsmenysController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }
        public IActionResult Index()
        {
            List<Person> people = _peopleRepository.GetAllPeople().ToList();

            return View(people);
        }
    }
}
