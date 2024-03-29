using System.ComponentModel.DataAnnotations;

namespace HelloDoc.Models
{
    public class BusinessViewModel
    {
        [Required]
        public string? BFirstName { get; set; }

        public string? BLastName { get; set; }
        [Required]
        public string? BPhoneNumber { get; set; }
        [Required]
        public string? BEmail { get; set; }
        [Required]
        public string? BName { get; set; }
        [Required]
        public string? BCaseNum { get; set; }
        public string? Discription { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string? Mobile { get; set; }


        public string? Street { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
