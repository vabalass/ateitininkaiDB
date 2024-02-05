using ateitiesDB.Interfaces;
using ateitiesDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ateitiesDB.ControllersView
{
    public class VienetaiController : Controller
    {
        private readonly IUnitsRepository _unitsRepository;

        public VienetaiController(IUnitsRepository unitsRepository)
        {
            _unitsRepository = unitsRepository;
        }
        public IActionResult Index()
        {
            List<Unit> units = _unitsRepository.GetAllUnits().ToList();

            return View(units);
        }
    }
}
