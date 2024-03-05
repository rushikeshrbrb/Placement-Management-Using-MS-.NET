using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationIdentity.Models
{
    public class JobApplication
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ApplicationId { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string? MobileNo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Experience must be a non-negative number")]
        public int? Experience { get; set; }

        // Assuming GraduationYear is a string representing a year
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Invalid graduation year")]
        public string? GraduationYear { get; set; }

        public string? skills { get; set; }

        public ApplicationStatus? Status { get; set; }

        /*// Define navigation properties for relationships
        [ForeignKey("Student")]
        public string? StudentId { get; set; }
        public Student Student { get; set; }
*/

        public string? User_id { get; set; }

        public string? StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; } // Navigation property to Student

        [ForeignKey("Company")]
        public string? Company_Id { get; set; }
        public Company Company { get; set; }

        [ForeignKey("AddJobs")]
        public string? Job_Id { get; set; }
        public AddJobs AddJobs { get; set; }
    }

    public enum ApplicationStatus
    {
        PENDING,
        APPROVED,
        REJECTED,
        SELECTED
    }

}
