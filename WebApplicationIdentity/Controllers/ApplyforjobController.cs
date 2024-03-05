using Microsoft.AspNetCore.Mvc;
using WebApplicationIdentity.Data;
using WebApplicationIdentity.DTO;
using WebApplicationIdentity.Models;

namespace WebApplicationIdentity.Controllers
{
    public class ApplyforjobController : Controller
    {

        private readonly MyDbContext _context;

        public ApplyforjobController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET: Applyforjob/Apply
        public IActionResult Apply(int jobId, string studentId, int companyId)
        {
            ApplyForJobDTO viewModel = new ApplyForJobDTO
            {
                JobId = jobId,
                StudentId = studentId,
                CompanyId = companyId
            };

            return View(viewModel);
        }

        // POST: Applyforjob/Apply
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply(ApplyForJobDTO viewModel)
        {
            if (ModelState.IsValid)
            {
                // Map the data from DTO to your entity model
                Applyforjob application = new Applyforjob
                {
                  /*  JobId = viewModel.JobId,
                    Student_Id = viewModel.StudentId,
                    CompanyId = viewModel.CompanyId,*/
                    Email = viewModel.Email,
                    MobileNo = viewModel.MobileNo,
                    Experience = viewModel.Experience,
                    GraduationYear = viewModel.GraduationYear,
                    TextareaValue = viewModel.TextareaValue
                    
                };

                // Add the application to the database and save changes
                _context.Applyforjob.Add(application);
                _context.SaveChanges();

                // Redirect to a success page or do any other necessary actions
                return RedirectToAction("Success");
            }

            // If the model state is not valid, return to the form with errors
            return View(viewModel);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
