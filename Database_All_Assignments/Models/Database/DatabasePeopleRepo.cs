﻿using Database_All_Assignments.Models.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_All_Assignments.Models.Database
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly IdentityContentDbContext _peopleDbContext;

        public DatabasePeopleRepo(IdentityContentDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Person Create(Person person)
        {
            /*Person addingPerson = new Person(FirstName, LastName, PhoneNumber, Address);
            addingPerson.PersonLanguages = allPerson;*/
            Person addingPerson = person;
            _peopleDbContext.GetPeopleList.Add(addingPerson);
            _peopleDbContext.SaveChanges();
            return addingPerson;

        }

        public bool Delete(Person person)
        {
            bool delete = true;

            if (delete == true)
            {
                _peopleDbContext.GetPeopleList.Remove(person);
                _peopleDbContext.SaveChanges();
            }

            return delete;
        }

        public List<Person> Read()
        {
            return _peopleDbContext.GetPeopleList.ToList();
        }

        public Person Read(int id)
        {
            return _peopleDbContext.GetPeopleList.SingleOrDefault(getPeopleList => getPeopleList.PersonID == id);
        }

        public Person Update(Person person)
        {
            _peopleDbContext.Update(person);
            _peopleDbContext.SaveChanges();
            return (person);
        }
    }
}
