using ateitiesDB.Data.DbContextFiles;
using Microsoft.AspNetCore.Mvc;

namespace ateitiesDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly AteitininkaiContext _context;

        public TestController(AteitininkaiContext context)
        {
            _context = context;
        }

        [HttpGet("People")]
        public ActionResult GetPeople()
        {
            var people = _context.Asmuos;

            return Ok(people);
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Good!");
        }


    }
}
