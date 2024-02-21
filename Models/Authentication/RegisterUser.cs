using System.ComponentModel.DataAnnotations;

namespace trytryuntilyoudie7.Models.Authentication
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Username is required")]  //attribute
        public string Username { get; set; } //properties

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
