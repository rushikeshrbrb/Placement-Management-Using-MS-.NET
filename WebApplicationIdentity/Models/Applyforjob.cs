using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationIdentity.Models
{
    public class Applyforjob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? ApplicationId { get; set; }

        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public int? Experience { get; set; }
        public string? GraduationYear { get; set; }
        public string? TextareaValue { get; set; }

        public string? Resume { get; set; }


        [ForeignKey("Job_Id")]
        public AddJobs? Job { get; set; }

        [ForeignKey("StudentId")]
        public Student? Student { get; set; }

        [ForeignKey("Company_Id")]
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }


        [EnumDataType(typeof(ApplicationStatus))]
        [Column(name: "Status")]

        public ApplicationStatus Status { get; set; }

        public string? Remark { get; set; }
    }

  /*  public enum ApplicationStatus
    {
        PENDING,
        APPROVED,
        REJECTED,
        SELECTED
    }*/
}
