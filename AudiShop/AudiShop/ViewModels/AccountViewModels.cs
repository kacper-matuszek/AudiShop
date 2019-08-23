using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudiShop.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please write your e-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please write your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please write your e-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please write your password")]
        [StringLength(30, ErrorMessage = "{0} have to have at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Your password is different from confirmation password.")]
        public string ConfirmPassword { get; set; }
    }
}