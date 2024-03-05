using System.ComponentModel.DataAnnotations;

namespace WebApplicationIdentity.DTO
{
    public class ApplyForJobDTO
    {
        public int JobId { get; set; }
        public string StudentId { get; set; }
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid mobile number.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Experience is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Experience must be a non-negative number.")]
        public int Experience { get; set; }

        [Required(ErrorMessage = "Graduation year is required.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Invalid graduation year.")]
        public string GraduationYear { get; set; }

        [Required(ErrorMessage = "Skills are required.")]
        public string TextareaValue { get; set; }
    }
}
