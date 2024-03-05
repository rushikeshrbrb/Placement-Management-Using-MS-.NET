using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationIdentity.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string StudentId { get; set; }

        // Other properties for the Student model
        [Required(ErrorMessage = "StudentName is required.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only letters are allowed.")]
        public string? StudentName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        public string? email { get; set; }

        // Foreign key to link to ApplicationUser
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        // Property to store resume file path
        public string? ResumeFilePath { get; set; }

/*        public ICollection<Applyforjob> Applyforjobs { get; set; }*/
        public ICollection<JobApplication> JobApplications { get; set; } // Navigation property to JobApplications

    }
}
