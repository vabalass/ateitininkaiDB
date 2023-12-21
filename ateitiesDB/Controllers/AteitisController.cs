using ateitiesDB.Interfaces;
using ateitiesDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AteitisManagement.Controllers
{
    public class AteitisController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;

        public AteitisController(IPeopleRepository peopleRepository)
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
