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
            using (var memoryStream = new MemoryStream())
            {
                // CsvHelper configuration
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);

                // CsvWriter writes data to the memory stream
                using (var writer = new StreamWriter(memoryStream))
                using (var csv = new CsvWriter(writer, csvConfig))
                {
                    csv.WriteRecords(people);
                }

                memoryStream.Position = 0;

                return new FileStreamResult(memoryStream, "text/csv")
                {
                    FileDownloadName = "people.csv"
                };
            }
        }
    }
}
