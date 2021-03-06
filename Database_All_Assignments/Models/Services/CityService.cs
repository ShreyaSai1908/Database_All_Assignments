﻿using Database_All_Assignments.Models.Repositorys;
using Database_All_Assignments.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_All_Assignments.Models.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _cityRepo;
        private readonly IPeopleRepo _peopleRepo;
        //private readonly ICityService _cityService;

        /*public CityService(ICityRepo cityRepo, ICityService cityService)
        {
            _cityRepo = cityRepo;
            _cityService = cityService;
        }*/

        public CityService(ICityRepo cityRepo, IPeopleRepo peopleRepo)
        {
            _cityRepo = cityRepo;
            _peopleRepo = peopleRepo;
        }

        public City Add(CreateCityViewModel createCityViewModel)
        {
            /*if (_cityService.FindBy(createCityViewModel.cityList) == null)
            {
                return null;
            }*/

            List<Person> personInCity = new List<Person>();

            foreach (int personID in createCityViewModel.PeopleID)
            {
                Person person = _peopleRepo.Read(personID);
                personInCity.Add(person);
            }

            //Person person = _peopleRepo.Read(createCityViewModel.PersonID);
            //City city = _cityRepo.Create(person, createCityViewModel.States, createCityViewModel.CityName);

            City city = _cityRepo.Create(personInCity, createCityViewModel.States, createCityViewModel.CityName);
            return city;
        }

        public List<City> All()
        {
            return _cityRepo.Read();
        }

        public City Edit(int id, CreateCityViewModel edit)
        {
            City editedCity = new City() { Id = id, PersonInCity = edit.PersonInCity, States = edit.States, CityName = edit.CityName };

            return _cityRepo.Update(editedCity);
        }

        public City FindBy(int id)
        {
            return _cityRepo.Read(id);
        }

        public List<Person> FindAllPerson(int id)
        {
            return _cityRepo.ReadAllPersonInCity(id);
        }


        public bool Remove(int id)
        {
            return _cityRepo.Delete(FindBy(id));
        }
    }
}
