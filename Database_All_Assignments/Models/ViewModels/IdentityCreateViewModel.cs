﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Database_All_Assignments.Models.ViewModels
{
    public class IdentityCreateViewModel
    {
        [Required]
        [StringLength(18, MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 2)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(18, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }        

        [Required]
        [StringLength(30, MinimumLength=6, ErrorMessage = "Password must be 6 long atleast 1 uppercase letter, a lowercase letter, a digit & a symbol.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength=6)]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ControlPassword { get; set; }
    }
}
