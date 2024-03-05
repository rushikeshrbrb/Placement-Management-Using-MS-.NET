using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationIdentity.Models
{
    public class EducationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string StudentEducation_Id { get; set; }

        [Required(ErrorMessage = "passing year is required.")]
        [Range(1900, int.MaxValue, ErrorMessage = "Please enter a valid passing year for Class 10.")]
        public int Class10_Passing_Year { get; set; }

        [Required(ErrorMessage = "percentage is required.")]
        [Range(0, 100, ErrorMessage = "Please enter a valid percentage for Class 10.")]
        public double Class10_Percentage { get; set; }

        [Required(ErrorMessage = "passing year is required.")]
        [Range(1900, int.MaxValue, ErrorMessage = "Please enter a valid passing year for Class 12.")]
        public int Class12_Passing_Year { get; set; }

        [Required(ErrorMessage = "percentage is required.")]
        [Range(0, 100, ErrorMessage = "Please enter a valid percentage for Class 12.")]
        public double Class12_Percentage { get; set; }

        [Required(ErrorMessage = "passing year is required.")]
        [Range(1900, int.MaxValue, ErrorMessage = "Please enter a valid completion year for Graduation.")]
        public int Graduation_Completion_Year { get; set; }

        [Required(ErrorMessage = "percentage is required.")]
        [Range(0, 100, ErrorMessage = "Please enter a valid percentage for Graduation.")]
        public double Graduation_Percentage { get; set; }

        [ForeignKey("Student_Id")]
        public Student Student { get; set; }


        // Custom validation for passing years not more than the current year
        [CurrentYear(ErrorMessage = "Passing year cannot be in the future.")]
        public class CurrentYearAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                int year = (int)value;
                int currentYear = DateTime.Now.Year;

                if (year > currentYear)
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }
        }
    }
}
