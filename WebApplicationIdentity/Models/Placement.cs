using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationIdentity.Models
{
    public class Placement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Placement_Id { get; set; }

        public string Student_Id { get; set; }

        [Required(ErrorMessage = "Placement Status is required.")]
        [RegularExpression("^(Placed|Unplaced)$", ErrorMessage = "Placement Status should be 'Placed' or 'Unplaced'.")]
        public string Placement_Status { get; set; }

        [Required(ErrorMessage = "Placement Company is required.")]
        public string Placement_Company { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Placement Salary should be a non-negative number.")]
        public double Placement_Salary { get; set; }

        [ForeignKey("Student_Id")]
        public Student Student { get; set; }
    }

}
