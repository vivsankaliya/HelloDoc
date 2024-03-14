using System.ComponentModel.DataAnnotations;

namespace HelloDoc.Models
{
    public class FamFrdViewModel
    {
        [Required]
        public string? FFirstName { get; set; }

        public string? FLastName { get; set; }
        [Required]
        public string? FPhoneNumber { get; set; }
        [Required]
        public string? FEmail { get; set; }
        [Required]
        public string? FRelationName { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string? Mobile { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string? Street { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
