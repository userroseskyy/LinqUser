using LinqUser.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace LinqUser.Services.Register
{
    public class RegisterDto
    {
        [Required]
        
       
        public string FirstName { get; set; }
        [Required]
       
      
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
       
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "پسورد و تایید پسورد باید یکسان باشند.")]
        public string ConfirmPassword { get; set; }
     


    }


}
