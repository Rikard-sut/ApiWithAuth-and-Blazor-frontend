using System.ComponentModel.DataAnnotations;

namespace Application.Authentication
{
    public class RegisterUserRequest
    {
        [Required(ErrorMessage = "Username is Required!")]
        public string Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email Address is Required!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required!")]
        public string Password { get; set; }
    }
}
