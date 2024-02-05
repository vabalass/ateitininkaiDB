using ateitiesDB.Interfaces;
using ateitiesDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ateitiesDB.Repositories
{
    public class UnitsRepository : IUnitsRepository
    {
        private readonly AteitininkaiDbContext _context;
        public UnitsRepository(AteitininkaiDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Unit> GetAllUnits()
        {
            return _context.Units.ToList();
        }

        public Unit GetUnitById(int unitId)
        {
            var unit = _context.Units.Find(unitId);
            if (unit != null)
            {
                return unit;
            }

            return null;
        }

        public void AddUnit(Unit unit)
        {
            _context.Units.Add(unit);
            _context.SaveChanges();
        }
        public void UpdateUnit(Unit unit)
        {
            _context.Entry(unit).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUnit(int unitId)
        {
            var unit = _context.Units.Find(unitId);
            if (unit != null)
            {
                _context.Units.Remove(unit);
                _context.SaveChanges();
            }
        }
    }
}
