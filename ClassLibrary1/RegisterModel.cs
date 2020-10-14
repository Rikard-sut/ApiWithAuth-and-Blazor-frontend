using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithAuth.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is Required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email Address is Required!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required!")]
        public string Password { get; set; }


    }
}
