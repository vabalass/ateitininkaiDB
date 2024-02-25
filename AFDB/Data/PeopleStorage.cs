using AFDB.Models;

namespace AFDB.Data
{
    public static class PeopleStorage
    {
        private static IEnumerable<Person>? _people;

        public static IEnumerable<Person> GetPeople()
        {
            return _people;
        }

        public static void SetPeople(IEnumerable<Person> people)
        {
            _people = people;
        }
    }
}
