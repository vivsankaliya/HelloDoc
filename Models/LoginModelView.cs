using System.ComponentModel.DataAnnotations;

namespace HelloDoc.Models
{
    public class LoginModelView
    {
        //[Required]
        //public string Email { get; set; } = null!;

        //[Required]
        //public string PasswordHash { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;
    }
}
