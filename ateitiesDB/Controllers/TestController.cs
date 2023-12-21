using ateitiesDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ateitiesDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly AteitininkaiDbContext _context;

        public TestController(AteitininkaiDbContext context)
        {
            _context = context;
        }

        [HttpGet("People")]
        public ActionResult GetPeople()
        {
            var people = _context.People;

            return Ok(people);
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Good!");
        }


    }
}
