using AFDB.Data;
using AFDB.Interfaces;
using AFDB.Models;
using AFDB.Services;
using Microsoft.EntityFrameworkCore;

namespace AFDB.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly AteitininkaiDbContext _context;
        public PeopleRepository(AteitininkaiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _context.People.ToList();
        }

        public IEnumerable<PersonFull> GetAllFullPeople()
        {
            return _context.PersonFulls.ToList();
        }

        public Person GetPersonById(int personId)
        {
            var Person = _context.People
                      .Include(p => p.Attendsevents)
                      .Include(p => p.Belongstounits)
                      .Include(p => p.Pledges)
                      .Where(p => p.Id == personId)
                      .FirstOrDefault();
            if (Person != null)
            {
                return Person;
            }
            else
            {
                return null;
            }
        }

        public Person AddPerson(Person Person)
        {
            _context.People.Add(Person);
            _context.SaveChanges();
            return Person;
        }

        public void AddPeople(IEnumerable<Person> people)
        {
            _context.People.AddRange(people);
            _context.SaveChanges();
        }
        public void UpdatePerson(Person updatedPerson)
        {
            
            var existingPerson = GetPersonById(updatedPerson.Id);

            try
            {
                existingPerson.Firstname = updatedPerson.Firstname;
                existingPerson.Lastname = updatedPerson.Lastname;
                existingPerson.Gender = updatedPerson.Gender;
                existingPerson.Birthdate = updatedPerson.Birthdate;
                existingPerson.Email = updatedPerson.Email;
                existingPerson.Phone = updatedPerson.Phone;
                existingPerson.Country = updatedPerson.Country;
                existingPerson.Description = updatedPerson.Description;
                existingPerson.Street = updatedPerson.Street;
                existingPerson.City = updatedPerson.City;
                existingPerson.House = updatedPerson.House;
                existingPerson.Apartment = updatedPerson.Apartment;

                foreach (var updatedPledge in updatedPerson.Pledges)
                {
                    // Check if a pledge with the same association already exists
                    var existingPledge = existingPerson.Pledges.FirstOrDefault(p => p.Association == updatedPledge.Association);

                    if (existingPledge == null)
                    {
                        // If the pledge with the same association doesn't exist, add a new one
                        existingPerson.Pledges.Add(new Pledge
                        {
                            Association = updatedPledge.Association,
                            Date = updatedPledge.Date,
                            Personid = updatedPerson.Id
                        });
                    }
                    else
                    {
                        // If the pledge with the same association exists, update its date
                        existingPledge.Date = updatedPledge.Date;
                    }
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); 
            }
        }

        public void DeletePerson(int personId)
        {
            var Person = _context.People.Find(personId);
            if (Person != null)
            {
                _context.People.Remove(Person);
                _context.SaveChangesAsync();
            }
        }
        public async Task DeletePersonAsync(int personId)
        {
            var person = await _context.People.FindAsync(personId);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Membershipfeefull> SearchForPeopleWithFee(IEnumerable<Membershipfeefull> fees)
        {
            foreach (var fee in fees)
            {
                // Search for people using the provided information
                PersonFull? matchingPerson = SearchPeople(fee.Personfirstname, fee.Personlastname);

                if (matchingPerson != null)
                {
                    fee.Personid = matchingPerson.Id;
                }
            }

            return fees;
        }

        public PersonFull? SearchPeople(string firstName, string lastName)
        {
            var people = _context.PersonFulls
                .Where(p => p.Firstname == firstName && p.Lastname == lastName)
                .OrderByDescending(p => p.Registrationdate)
                .ToList();

            if (people.Count == 1)
            {
                return people[0];
            }
            else if(people.Count > 1)
            {
                return people.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
