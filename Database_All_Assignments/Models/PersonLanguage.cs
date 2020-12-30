﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Database_All_Assignments.Models
{
    public class PersonLanguage
    {
        [Key]
        public int PersonLangID { get; set; }
        public List <Person> PersonList { get; set; }

        public List <Language> LanguageList { get; set; }
    }
}
