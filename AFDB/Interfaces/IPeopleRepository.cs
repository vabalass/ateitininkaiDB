using AFDB.Models;

namespace AFDB.Interfaces
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetAllPeople();
        IEnumerable<PersonFull> GetAllFullPeople();
        Person GetPersonById(int personId);
        Person AddPerson(Person Person); //returns new Person
        void AddPeople(IEnumerable<Person> people);
        void UpdatePerson(Person Person);
        void DeletePerson(int personId);
        Task DeletePersonAsync(int personId);
    }
}
