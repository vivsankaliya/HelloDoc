using System.ComponentModel.DataAnnotations;

namespace HelloDoc.Models
{
    public class ConciergeViewModel
    {
        [Required]
        public string? CFirstName { get; set; }

        public string? CLastName { get; set; }
        [Required]
        public string? CPhoneNumber { get; set; }
        [Required]
        public string? CEmail { get; set; }
        [Required]
        public string? CRelationName { get; set; }
        public string? Discription { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string? Mobile { get; set; }


        public string CStreet { get; set; } = null!;
        [Required]
        public string CCity { get; set; } = null!;
        [Required]
        public string CState { get; set; } = null!;
        [Required]
        public string CZipCode { get; set; } = null!;
    }
}
