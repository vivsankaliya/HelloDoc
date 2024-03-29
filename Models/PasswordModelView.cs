using System.ComponentModel.DataAnnotations;

namespace HelloDoc.Models
{
    public class PasswordModelView
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string? Password { get; set; } = null!;

        [Required]
        [Compare("Password", ErrorMessage = "password must be same...")]
        public string? confirmPassword { get; set; }


    }

}