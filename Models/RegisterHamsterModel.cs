using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class RegisterHamsterModel : BaseEntity
    {
        [Required(ErrorMessage = "First Name is required and needs to be longer than 2 characters!")]
        [MinLength(2)]
        public string HamsterFirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required and needs to be longer than 2 characters!")]
        [MinLength(2)]
        public string HamsterLastName { get; set; }
        [Required(ErrorMessage = "Password is required and needs to be longer than 8 characters!")]
        [MinLength(8)]
        public string HamsterPassword { get; set; }
        [Required(ErrorMessage = "A valid Email is needed!")]
        [EmailAddress]
        public string HamsterEmail { get; set; }
        [Required(ErrorMessage = "Passwords must match!")]
        [Compare("HamsterPassword")]
        public string ConfirmPassword { get; set; }
    }
}