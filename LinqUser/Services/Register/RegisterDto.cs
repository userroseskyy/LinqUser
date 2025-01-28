using LinqUser.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace LinqUser.Services.Register
{
    public class RegisterDto
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s]+$", ErrorMessage = "فقط حروف فارسی، انگلیسی و فاصله‌ها مجاز هستند.")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s]+$", ErrorMessage = "فقط حروف فارسی، انگلیسی و فاصله‌ها مجاز هستند.")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "پسورد باید حداقل 6 کاراکتر باشد.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$",
                        ErrorMessage = "پسورد باید حداقل شامل یک حرف بزرگ، یک عدد و یک نماد خاص باشد.")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "پسورد و تایید پسورد باید یکسان باشند.")]
        public string ConfirmPassword { get; set; }


    }


}
