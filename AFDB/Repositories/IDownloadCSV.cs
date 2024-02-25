using AFDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace AFDB.Repositories
{
    public interface IDownloadCSV
    {
        IActionResult DownloadPeopleCSV(IEnumerable<Person> people);
    }
}
