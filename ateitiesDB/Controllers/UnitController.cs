using ateitiesDB.DtoModels;
using ateitiesDB.Interfaces;
using ateitiesDB.Models;
using ateitiesDB.Repositories;
using ateitiesDB.Services.DtoConverter;
using Microsoft.AspNetCore.Mvc;

namespace ateitiesDB.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitsRepository _unitsRepository;
        private readonly IDtoToModel _dtoToModel;
        public UnitController(IUnitsRepository unitsRepository, IDtoToModel dtoToModel)
        {
            _unitsRepository = unitsRepository;
            _dtoToModel = dtoToModel;
        }

        [HttpGet("GetUnits")]
        public ActionResult GetUnits()
        {
            try
            {
                var units = _unitsRepository.GetAllUnits();
                return Ok(units);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GetUnit")]
        public ActionResult GetUnit([FromBody] int id)
        {
            try
            {
                var unit = _unitsRepository.GetUnitById(id);
                if (unit != null)
                {
                    return Ok(unit);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return StatusCode(500, "Returned unit null");
        }

        [HttpPost("AddUnit")]
        public ActionResult AddUnit([FromBody] UnitDto unitDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var unit = _dtoToModel.DtoUnit(unitDto);
                _unitsRepository.AddUnit(unit);

                return Ok(unit);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteUnit")]
        public IActionResult DeleteUnit([FromBody] int id)
        {
            try
            {
                _unitsRepository.DeleteUnit(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateUnit")]
        public IActionResult UpdateUnit([FromBody] Unit unit)
        {
            try
            {
                _unitsRepository.UpdateUnit(unit);
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
