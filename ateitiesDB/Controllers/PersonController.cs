using ateitiesDB.DtoModels;
using ateitiesDB.Interfaces;
using ateitiesDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ateitiesDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IDtoToModel _dtoToModel;

        public PersonController(IPeopleRepository peopleRepository, IDtoToModel dtoToModel)
        {
            _peopleRepository = peopleRepository;
            _dtoToModel = dtoToModel;
        }

        [HttpGet("GetPeople")]
        public ActionResult GetPeople()
        {
            try
            {
                var people = _peopleRepository.GetAllPeople();
                return Ok(people);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GetPerson")]
        public ActionResult GetPerson([FromBody] int id)
        {
            try
            {
                var person = _peopleRepository.GetPersonById(id);
                if (person != null)
                {
                    return Ok(person);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return StatusCode(500, "Returned person null");
        }

        [HttpPost("AddPerson")]
        public ActionResult AddPerson([FromBody] PersonDto personDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var person = _dtoToModel.DtoToPerson(personDto);
                _peopleRepository.AddPerson(person);

                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeletePerson")]
        public IActionResult DeletePerson([FromBody] int id)
        {
            try
            {
                _peopleRepository.DeletePerson(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdatePerson")]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            try
            {
                _peopleRepository.UpdatePerson(person);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
