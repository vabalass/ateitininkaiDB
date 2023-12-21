using Microsoft.AspNetCore.Mvc;

namespace AteitisManagement.Controllers
{
    public class AteitisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
