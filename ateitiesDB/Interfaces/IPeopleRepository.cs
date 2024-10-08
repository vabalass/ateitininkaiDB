﻿using ateitiesDB.Models;

namespace ateitiesDB.Interfaces
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPersonById(int personId);
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int personId);
    }
}
