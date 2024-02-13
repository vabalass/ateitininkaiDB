using AFDB.Models;

namespace AFDB.Interfaces
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPersonById(int personId);
        void AddPerson(Person Person);
        void UpdatePerson(Person Person);
        void DeletePerson(int personId);
    }
}
