using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationIdentity.Models
{
    public class AddJobs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Job_Id { get; set; }

        public string? Company_Id { get; set; }

        [Required(ErrorMessage = "Designation is required.")]
        public string? Designation { get; set; }

        [Required(ErrorMessage = "Specialization is required.")]
        public string? Specialization { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Experience should be a non-negative number.")]
        public int? Experience { get; set; }


        public string? Description { get; set; }

      
        [MaxLength(255, ErrorMessage = "Criteria should not exceed 255 characters.")]
        public string? _10_cri { get; set; }

        [MaxLength(255, ErrorMessage = "Criteria should not exceed 255 characters.")]
        public string? _12_cri { get; set; }

        [MaxLength(255, ErrorMessage = "Criteria should not exceed 255 characters.")]
        public string? Grad_cri { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string? Status { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "CTC should be a non-negative number.")]
        public double? CTC { get; set; }


        [ForeignKey("Company_Id")]
        public Company Company { get; set; }

        public ICollection<Applyforjob> Applyforjobs { get; set; }
    }
}

