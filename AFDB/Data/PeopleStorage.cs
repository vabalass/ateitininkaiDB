using AFDB.Models;

namespace AFDB.Data
{
    public static class PeopleStorage
    {
        private static IEnumerable<Person>? _people;
        private static IEnumerable<PersonFull>? _peopleFull;

        public static IEnumerable<Person>? GetPeople()
        {
            return _people;
        }

        public static void SetPeople(IEnumerable<Person> people)
        {
            _people = people;
        }

        public static IEnumerable<PersonFull>? GetPeopleFull()
        {
            return _peopleFull;
        }

        public static void SetPeopleFull(IEnumerable<PersonFull> people)
        {
            _peopleFull = people;
        }
    }
}
