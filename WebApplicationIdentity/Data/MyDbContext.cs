using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationIdentity.Models;

namespace WebApplicationIdentity.Data
{
    public class MyDbContext:IdentityDbContext<ApplicationUser>
    {
        internal object Students;

        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<WebApplicationIdentity.Models.Student>? Student { get; set; }
        public DbSet<WebApplicationIdentity.Models.Company>? Companies { get; set; }
        public DbSet<WebApplicationIdentity.Models.Contact>? Contact { get; set; }

        public DbSet<WebApplicationIdentity.Models.EducationModel>? EducationModel { get; set; }

        public DbSet<WebApplicationIdentity.Models.Placement>? placements { get; set; }
        public DbSet<WebApplicationIdentity.Models.AddJobs>? AddJobs { get; set; } 
        public DbSet<WebApplicationIdentity.Models.Applyforjob>? Applyforjob { get; set; }

        public DbSet<WebApplicationIdentity.Models.JobApplication>? JobApplications { get; set; }



    }
}
