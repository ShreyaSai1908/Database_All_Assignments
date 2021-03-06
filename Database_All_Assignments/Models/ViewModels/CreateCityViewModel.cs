﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database_All_Assignments.Models.ViewModels
{
    public class CreateCityViewModel
    {
        public List<City> CityList { get; set; }
        public List<Person> PersonInCity { get; set; }

        public int updateCityID { get; set; }

        public List<int> PeopleID { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public string States { get; set; }
    }
}
