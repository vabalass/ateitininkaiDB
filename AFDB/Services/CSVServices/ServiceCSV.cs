using AFDB.Interfaces;
using AFDB.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Text;

namespace AFDB.Services.CSVServices
{
    public class ServiceCSV : IServiceCSV
    {
        public sealed class RealPersonCsvMap : ClassMap<Person>
        {
            public RealPersonCsvMap()
            {
                Map(m => m.Id).Name("Id");
                Map(m => m.Firstname).Name("Vardas");
                Map(m => m.Lastname).Name("Pavardė");
                Map(m => m.Gender).Name("Lytis");
                Map(m => m.Birthdate).Name("Gimimo data");
                Map(m => m.Email).Name("El. paštas");
                Map(m => m.Phone).Name("Tel. nr.");
                Map(m => m.Description).Name("Aprašymas");
                Map(m => m.Country).Name("Šalis");
                Map(m => m.City).Name("Miestas");
                Map(m => m.Street).Name("Gatvė");
                Map(m => m.House).Name("Namas");
                Map(m => m.Apartment).Name("Butas");
                Map(m => m.Registrationdate).Name("Registracijos data");
            }
        }

        public sealed class PersonFullCsvMap : ClassMap<PersonFull>
        {
            public PersonFullCsvMap()
            {
                Map(m => m.Id).Name("Id");
                Map(m => m.Firstname).Name("Vardas");
                Map(m => m.Lastname).Name("Pavardė");
                Map(m => m.Age).Name("Amžius");
                Map(m => m.Gender).Name("Lytis");
                Map(m => m.Membershipstatus).Name("Narystė");
                Map(m => m.Email).Name("El. paštas");
                Map(m => m.Phone).Name("Tel. nr.");
                Map(m => m.Description).Name("Aprašymas");
                Map(m => m.Country).Name("Šalis");
                Map(m => m.Address).Name("Adresas");
                Map(m => m.Registrationdate).Name("Registracijos data");
            }
        }

        public sealed class ExamplePersonCsvMap : ClassMap<Person>
        {
            public ExamplePersonCsvMap()
            {
                Map(m => m.Id).Name("Id");
                Map(m => m.Firstname).Name("Vardas");
                Map(m => m.Lastname).Name("Pavardė");
                Map(m => m.Gender).Name("Lytis");
                Map(m => m.Birthdate).Name("Gimimo data");
                Map(m => m.Email).Name("El. paštas");
                Map(m => m.Phone).Name("Tel. nr.");
                Map(m => m.Description).Name("Aprašymas");
                Map(m => m.Country).Name("Šalis");
                Map(m => m.City).Name("Miestas");
                Map(m => m.Street).Name("Gatvė");
                Map(m => m.House).Name("Namas");
                Map(m => m.Apartment).Name("Butas");
                // Exclude properties
                Map(m => m.Id).Ignore();
                Map(m => m.Registrationdate).Ignore();
            }
        }

        public IActionResult DownloadPeopleFullCSV(IEnumerable<PersonFull> people)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8))
            using (CsvWriter csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Context.RegisterClassMap(new PersonFullCsvMap());
                csv.WriteRecords(people);
                writer.Flush();

                memoryStream.Seek(0, SeekOrigin.Begin);

                return new FileContentResult(memoryStream.ToArray(), "text/csv")
                {
                    FileDownloadName = $"AFasmenys_{DateTime.Now:yyyyMMddHHmmss}.csv"
                };
            }
        }

        //content type true - with creation date and person ID, false - without.
        public IActionResult DownloadPeopleCSV(IEnumerable<Person> people, bool contentType)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8))
            using (CsvWriter csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Context.RegisterClassMap(contentType ? new RealPersonCsvMap() : new ExamplePersonCsvMap());
                csv.WriteRecords(people);
                writer.Flush();

                memoryStream.Seek(0, SeekOrigin.Begin);

                return new FileContentResult(memoryStream.ToArray(), "text/csv")
                {
                    FileDownloadName = $"AFasmenys_{DateTime.Now:yyyyMMddHHmmss}.csv"
                };
            }
        }

        public IEnumerable<Person> ReadPeopleCSV(Stream csvStream, bool contentType)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture);
            configuration.HeaderValidated = null; // Disable header validation
            configuration.MissingFieldFound = null; // Disable missing field detection

            using (var reader = new StreamReader(csvStream, Encoding.UTF8))
            using (var csv = new CsvReader(reader, configuration))
            {
                // Register the class map based on content type
                csv.Context.RegisterClassMap(contentType ? new RealPersonCsvMap() : (ClassMap<Person>)new ExamplePersonCsvMap());

                return csv.GetRecords<Person>().ToList();
            }
        }

        public IEnumerable<Person> generateRandomPeopleList(int numberOfPeople)
        {
            var random = new Random();
            var peopleList = new List<Person>();

            for (int i = 1; i <= numberOfPeople; i++)
            {
                var person = new Person
                {
                    Firstname = $"Vardenis{i}",
                    Lastname = $"Pavardenis{i}",
                    Gender = i % 2 == 0 ? "vyr" : "mot",
                    Birthdate = new DateOnly(random.Next(1970, 2000), random.Next(1, 13), random.Next(1, 29)),
                    Email = $"pastas{i}@example.com",
                    Phone = $"+3706111111{i}",
                    Country = "Lietuva",
                    Description = $"Dirba per {i} darbus.",
                    Street = $"Laisvės al. {i}",
                    City = $"Kaunas{i}",
                    House = $"13",
                    Apartment = $"{i}",
                };

                peopleList.Add(person);
            }

            return peopleList;
        }
    }
}
