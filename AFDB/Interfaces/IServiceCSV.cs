using AFDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AFDB.Interfaces
{
    public interface IServiceCSV
    {
        IActionResult DownloadPeopleFullCSV(IEnumerable<PersonFull> people);
        //content type true - with creation date and person ID, false - without.
        IActionResult DownloadPeopleCSV(IEnumerable<Person> people, bool contentType);
        IEnumerable<Person> ReadPeopleCSV(Stream csvStream, bool contentType);
        IEnumerable<Person> generateRandomPeopleList(int numberOfPeople);
    }
}
