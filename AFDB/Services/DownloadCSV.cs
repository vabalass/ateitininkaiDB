using AFDB.Models;
using AFDB.Repositories;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace AFDB.Services
{
    public class DownloadCSV : IDownloadCSV
    {
        public IActionResult DownloadPeopleCSV(IEnumerable<Person> people)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(memoryStream))
            using (CsvWriter csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(people);
                writer.Flush();

                // Set the position of the memory stream to the beginning
                memoryStream.Seek(0, SeekOrigin.Begin);

                // Return a FileResult with the CSV data
                return new FileContentResult(memoryStream.ToArray(), "text/csv")
                {
                    FileDownloadName = $"people_{DateTime.Now:yyyyMMddHHmmss}.csv"
                };
            }
        }
    }
}
