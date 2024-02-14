using AFDB.Models;

namespace AFDB.Interfaces
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPersonById(int personId);
        Person AddPerson(Person Person); //returns new Person
        void UpdatePerson(Person Person);
        void DeletePerson(int personId);
    }
}
