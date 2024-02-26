using AFDB.Models;

namespace AFDB.Data
{
    public static class PeopleStorage
    {
        private static IEnumerable<Person>? _people;
        private static Person? _currentPerson;

        public static IEnumerable<Person> GetPeople()
        {
            return _people;
        }

        public static void SetPeople(IEnumerable<Person> people)
        {
            _people = people;
        }

        public static Person GetPerson()
        {
            return _currentPerson;
        }

        public static void SetPerson(Person person)
        {
            _currentPerson = person;
        }
    }
}
