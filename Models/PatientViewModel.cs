using System.ComponentModel.DataAnnotations;

namespace HelloDoc.Models
{
    public class PatientViewModel
    {
        public string? Discription { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string? Mobile { get; set; }

        public DateTime BirthDate { get; set; }
        [Required]
        public string? Street { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        public string? ZipCode { get; set; }

        public IFormFile ImgPath { get; set; }

        public string FileName { get; set; }
    }
}
