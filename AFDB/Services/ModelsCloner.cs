using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using AFDB.Models;
using System.Text.Json;

namespace AFDB.Services
{
    public class ModelsCloner
    {
        public static Person? ClonePerson(Person originalPerson)
        {
            if (originalPerson == null)
            {
                return null;
            }

            string jsonString = JsonSerializer.Serialize(originalPerson);
            var deserializedPerson = JsonSerializer.Deserialize<Person>(jsonString);
            return deserializedPerson;
        }

        public static IEnumerable<Person>? ClonePeople(IEnumerable<Person> originalPeople)
        {
            if (originalPeople == null)
            {
                return null;
            }

            string jsonString = JsonSerializer.Serialize(originalPeople);
            var deserializedPeople = JsonSerializer.Deserialize<IEnumerable<Person>>(jsonString);
            return deserializedPeople ?? Enumerable.Empty<Person>();
        }
    }
}
