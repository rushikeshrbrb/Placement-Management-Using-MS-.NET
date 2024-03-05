using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationIdentity.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Company_Id { get; set; }

        [Required(ErrorMessage = "Name of Representative is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name of Representative must contain only letters.")]
        public string? nameOfRepresentative { get; set; }

        [Required(ErrorMessage = "Company Name is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Company Name must contain only letters.")]
        public string? Company_Name { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public string? User_id { get; set; }

        [Url(ErrorMessage = "Invalid website format.")]
        public string? Website { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City must contain only letters.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        [RegularExpression(@"^\+91[1-9]\d{9}$", ErrorMessage = "Invalid Indian phone number.")]
        public string? Contact_No { get; set; }

        public AddJobs? addjob { get; set; }


 

        [ForeignKey("User_id")]
        public ApplicationUser User { get; set; }

        public ICollection<Applyforjob> Applyforjobs { get; set; }
    }
}
