using AFDB.Interfaces;
using AFDB.Models;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using static AFDB.Services.CSVServices.ServiceCSV;
using System.Globalization;
using System.Text;
using CsvHelper;
using AFDB.OthetModels.ModelsForFileReading;

namespace AFDB.Services.CSVServices
{
    public class MembershipFeesServiceCSV : IMembershipFeesServiceCSV
    {
        public IActionResult DownloadMemvershipFeesFileReadCSV(IEnumerable<Membershipfeefull> fees)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8))
            using (CsvWriter csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Context.RegisterClassMap(new MembershipFeeFileReadCsvMap());
                csv.WriteRecords(fees);
                writer.Flush();

                memoryStream.Seek(0, SeekOrigin.Begin);

                return new FileContentResult(memoryStream.ToArray(), "text/csv")
                {
                    FileDownloadName = $"Pavyzdys_Nario_mokesciai_{DateTime.Now:yyyyMMddHHmmss}.csv"
                };
            }
        }

        public IActionResult DownloadMemvershipFeesFullCSV(IEnumerable<Membershipfeefull> fees)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8))
            using (CsvWriter csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Context.RegisterClassMap(new MembershipFeeFullCsvMap());
                csv.WriteRecords(fees);
                writer.Flush();

                memoryStream.Seek(0, SeekOrigin.Begin);

                return new FileContentResult(memoryStream.ToArray(), "text/csv")
                {
                    FileDownloadName = $"AF_Nario_mokesciai_{DateTime.Now:yyyyMMddHHmmss}.csv"
                };
            }
        }

        public IEnumerable<Membershipfeefull> generateRandomMembershipFeeFullList(int numberOfFees)
        {
            var random = new Random();
            var feesList = new List<Membershipfeefull>();

            for (int i = 1; i <= numberOfFees; i++)
            {
                var membershipfeefull = new Membershipfeefull
                {
                    Personfirstname = $"Vardenis{i}",
                    Personlastname = $"Pavardenis{i}",
                    Paymentdate = new DateOnly(random.Next(2020, 2024), random.Next(1, 13), random.Next(1, 29)),
                    Membershipstatus = $"MAS",
                    Amount = (decimal)i + (decimal)0.14,
                    Description = $"Už narystę",
                };

                feesList.Add(membershipfeefull);
            }

            return feesList;
        }

        public IEnumerable<Membershipfeefull> ReadMembershipFeesCSV(Stream csvStream)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture);
            configuration.HeaderValidated = null; // Disable header validation
            configuration.MissingFieldFound = null; // Disable missing field detection

            using (var reader = new StreamReader(csvStream, Encoding.UTF8))
            using (var csv = new CsvReader(reader, configuration))
            {
                // Register the class map based on content type
                csv.Context.RegisterClassMap(new MembershipFeeReadCsvMap());

                var csvRecords = csv.GetRecords<MembershipfeeCsv>().ToList();

                // Filter out empty lines
                var nonEmptyCsvRecords = csvRecords
                    .Where(csvRecord =>
                        !string.IsNullOrWhiteSpace(csvRecord.Personfirstname) &&
                        !string.IsNullOrWhiteSpace(csvRecord.Personlastname) &&
                        !string.IsNullOrWhiteSpace(csvRecord.Membershipstatus))
                    .ToList();

                // Convert to Membershipfeefull
                var membershipfeefullRecords = nonEmptyCsvRecords.Select(csvRecord =>
                    new Membershipfeefull
                    {
                        Personfirstname = csvRecord.Personfirstname,
                        Personlastname = csvRecord.Personlastname,
                        Membershipstatus = csvRecord.Membershipstatus,
                        Amount = csvRecord.Amount,
                        Paymentdate = csvRecord.Paymentdate,
                        Description = csvRecord.Description
                    }).ToList();
                return membershipfeefullRecords;
            }
        }
    }
    public sealed class MembershipFeeFullCsvMap : ClassMap<Membershipfeefull>
    {
        public MembershipFeeFullCsvMap()
        {
            Map(m => m.Paymentid).Name("Id");
            Map(m => m.Personid).Name("Asmens Id");
            Map(m => m.Personfirstname).Name("Vardas");
            Map(m => m.Personlastname).Name("Pavardė");
            Map(m => m.Membershipstatus).Name("Narystė");
            Map(m => m.Amount).Name("Suma");
            Map(m => m.Paymentdate).Name("Pavedimo data");
            Map(m => m.Description).Name("Aprašymas");
        }
    }

    public sealed class MembershipFeeFileReadCsvMap : ClassMap<Membershipfeefull>
    {
        public MembershipFeeFileReadCsvMap()
        {
            Map(m => m.Personfirstname).Name("Vardas");
            Map(m => m.Personlastname).Name("Pavardė");
            Map(m => m.Membershipstatus).Name("Narystė");
            Map(m => m.Amount).Name("Suma");
            Map(m => m.Paymentdate).Name("Pavedimo data");
            Map(m => m.Description).Name("Aprašymas");
            //ignore
            Map(m => m.Personid).Ignore();
            Map(m => m.Paymentid).Ignore();
        }
    }

    public sealed class MembershipFeeReadCsvMap : ClassMap<MembershipfeeCsv>
    {
        public MembershipFeeReadCsvMap()
        {
            Map(m => m.Personfirstname).Name("Vardas");
            Map(m => m.Personlastname).Name("Pavardė");
            Map(m => m.Membershipstatus).Name("Narystė");
            Map(m => m.Amount).Name("Suma");
            Map(m => m.Paymentdate).Name("Pavedimo data");
            Map(m => m.Description).Name("Aprašymas");
        }
    }
}
