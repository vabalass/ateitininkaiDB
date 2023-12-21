using ateitiesDB.DtoModels;
using ateitiesDB.Interfaces;
using ateitiesDB.Models;

namespace ateitiesDB.Services.DtoConverter
{
    public class DtoToModel : IDtoToModel
    {
        public DtoToModel()
        {

        }
        public Person DtoToPerson(PersonDto person)
        {
            var newPerson = new Person
            {
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                Gender = person.Gender,
                Birthdate = person.Birthdate,
                Email = person.Email,
                Phone = person.Phone,
                Country = person.Country,
                Description = person.Description,
                Street = person.Street,
                City = person.City,
                House = person.House,
                Apartment = person.Apartment
            };

            return newPerson;
        }
    }
}
