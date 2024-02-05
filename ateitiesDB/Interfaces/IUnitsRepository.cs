using ateitiesDB.Models;

namespace ateitiesDB.Interfaces
{
    public interface IUnitsRepository
    {
        IEnumerable<Unit> GetAllUnits();
        Unit GetUnitById(int unitId);
        void AddUnit(Unit unit);
        void UpdateUnit(Unit unit);
        void DeleteUnit(int unitId);
    }
}
