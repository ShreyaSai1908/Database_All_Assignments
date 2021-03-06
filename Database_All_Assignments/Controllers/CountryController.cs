﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database_All_Assignments.Models;
using Database_All_Assignments.Models.Services;
using Database_All_Assignments.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Database_All_Assignments.Controllers
{
    
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public CountryController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }

        // GET: CountryController
        public ActionResult ShowCountry()
        {
            /*CreateCountryViewModel ctyVM = new CreateCountryViewModel();

            Country cty = new Country();

            cty.CountryName = "Default Country";
            cty.CountryId = 0;

            List<Country> countryList = new List<Country>();
            countryList.Add(cty);

            ctyVM.CountryList = countryList;*/

            CreateCountryViewModel ctyVM = new CreateCountryViewModel();
            ctyVM.CountryList = _countryService.All();
            return View(ctyVM);
            //return View("ShowCountry",ctyVM);
        }

        // GET: CountryController/Details/5
        public ActionResult CountryDetails(int id)
        {
            CreateCountryViewModel ctyVM = new CreateCountryViewModel();
            Country ctyDetails = _countryService.FindBy(id);

            ctyVM.CountryId = ctyDetails.CountryId;
            ctyVM.CountryName = ctyDetails.CountryName;
            //ctyVM.CityList = _cityService.All(); //gives all the cities in the database and not for this particular country 
            ctyVM.CityList = _countryService.FindAllCity(id); //gives all the cities in the database for this particular country 
            return View(ctyVM);
        }

        // GET: CountryController/Create
        public ActionResult CreateCountry()
        {
            CreateCountryViewModel ctyVM = new CreateCountryViewModel();
            ctyVM.CityList = _cityService.All();
            return View(ctyVM);
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCountry(CreateCountryViewModel ctyVM)
        {
            if (ModelState.IsValid)
            {
                Country country = _countryService.Add(ctyVM);

                if (country == null)
                {
                    ModelState.AddModelError("msg", "Database Problem");
                    return View(ctyVM);
                }

                return RedirectToAction(nameof(ShowCountry));
            }
            else
            {
                return View(ctyVM);
            }
        }

        // GET: CountryController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CreateCountryViewModel ctyVM = new CreateCountryViewModel();
            Country editCountry = _countryService.FindBy(id);
            ctyVM.CountryName = editCountry.CountryName;
            ctyVM.CountryId = editCountry.CountryId;

            List<City> allCities = _cityService.All();
            ctyVM.CityList = allCities;

            return View("Edit", ctyVM);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateCountryViewModel editCountry)
        {
            _countryService.Edit(editCountry.CountryId, editCountry);

            return RedirectToAction(nameof(ShowCountry));
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            _countryService.Remove(id);

            return RedirectToAction(nameof(ShowCountry));
        }

        // POST: CountryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ShowCountry));
            }
            catch
            {
                return View();
            }
        }
    }
}
