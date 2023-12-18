using ateitiesDB.Data.DbContextFiles;
using Microsoft.AspNetCore.Mvc;

namespace ateitiesDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly AteitisDbContext _context;

        public TestController(AteitisDbContext context)
        {
            _context = context;
        }

        [HttpGet("People")]
        public async ActionResult GetPeople()
        {
            var people = await _context.People;

            return Ok(people);
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Good!");
        }


    }
}
