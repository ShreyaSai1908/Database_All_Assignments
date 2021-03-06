﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Database_All_Assignments.Models
{
    public class Person
    {        
            public Person()
            {
            }

            public Person(string firstName, string lastName, string phoneNumber, string address)
            {
                FirstName = firstName;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Address = address;
            }

            [Key]
            public int PersonID { get; set; }

            [Required]
            [StringLength(80, MinimumLength = 1)]
            public string FirstName { get; set; }

            [Required]
            [StringLength(80, MinimumLength = 1)]
            public string LastName { get; set; }

            [Required]
            [StringLength(10, MinimumLength = 9)]
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(80, MinimumLength = 5)]
            public string Address { get; set; }

            public City City { get; set; }
            
            [NotMapped]
            public virtual List<Language> Languages { get; set; }

            [NotMapped]
            public virtual List<int> ListLanguageID { get; set; }

            public List<PersonLanguage> PersonLanguages { get; set; }//Many
    }

}
