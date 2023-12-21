using ateitiesDB.DtoModels;
using ateitiesDB.Models;

namespace ateitiesDB.Interfaces
{
    public interface IDtoToModel
    {
        Person DtoToPerson(PersonDto person);
    }
}
