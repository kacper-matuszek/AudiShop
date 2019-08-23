using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AudiShop.Models
{
    public class UserData
    {
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string Address{ get; set; }
        public string City{ get; set; }

        [RegularExpression(@"(\+\d{2})*[\d\s]+", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber{ get; set; }

        [EmailAddress(ErrorMessage = "Invalid format e-mail address.")]
        public string Email{ get; set; }
    }
}