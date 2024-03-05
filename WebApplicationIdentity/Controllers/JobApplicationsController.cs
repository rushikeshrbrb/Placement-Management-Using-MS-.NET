using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationIdentity.Data;
using WebApplicationIdentity.Models;

namespace WebApplicationIdentity.Controllers
{
    public class JobApplicationsController : Controller
    {
        private readonly MyDbContext _context;

        public JobApplicationsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: JobApplications
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.JobApplications.Include(j => j.AddJobs).Include(j => j.Company).Include(j => j.Student);
            return View(await myDbContext.ToListAsync());
        }

        // GET: JobApplications/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.JobApplications == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications
                .Include(j => j.AddJobs)
                .Include(j => j.Company)
                .Include(j => j.Student)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        /* // GET: JobApplications/Create
         public IActionResult Create()
         {
             ViewData["Job_Id"] = new SelectList(_context.AddJobs, "Job_Id", "Job_Id");
             ViewData["Company_Id"] = new SelectList(_context.Companies, "Company_Id", "Company_Id");
             ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");
             return View();
         }*/

        // GET: JobApplications/Create
        public IActionResult Create(string companyId, string jobId)
        {
            // Assuming you have some logic to retrieve the current student's ID
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           
            var viewModel = new JobApplication
            {
                Company_Id = companyId,
                Job_Id = jobId,
                User_id = currentUserId
            };

            return View(viewModel);
        }



        // POST: JobApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("ApplicationId,Email,MobileNo,Experience,GraduationYear,skills,Status,User_id,Company_Id,Job_Id")] JobApplication jobApplication)
         {
            
                 _context.Add(jobApplication);
                 await _context.SaveChangesAsync();

            return RedirectToAction("GetAllCompanies", "Students");

           /* string url = Url.Action("JobInfo", "Students");

            // Redirect to the generated URL
            return Redirect(url);*/

            /* return RedirectToAction("JobInfo", "Students", new { userId = jobApplication.User_id }); // Assuming you need to pass the user ID to JobInfo
 */
            return RedirectToAction(nameof(Index));
           
             ViewData["Job_Id"] = new SelectList(_context.AddJobs, "Job_Id", "Job_Id", jobApplication.Job_Id);
             ViewData["Company_Id"] = new SelectList(_context.Companies, "Company_Id", "Company_Id", jobApplication.Company_Id);
             ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", jobApplication.StudentId);
             return View(jobApplication);
         }

        // GET: JobApplications/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.JobApplications == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication == null)
            {
                return NotFound();
            }
            ViewData["Job_Id"] = new SelectList(_context.AddJobs, "Job_Id", "Job_Id", jobApplication.Job_Id);
            ViewData["Company_Id"] = new SelectList(_context.Companies, "Company_Id", "Company_Id", jobApplication.Company_Id);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", jobApplication.StudentId);
            return View(jobApplication);
        }

        // POST: JobApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ApplicationId,Email,MobileNo,Experience,GraduationYear,skills,Status,StudentId,Company_Id,Job_Id")] JobApplication jobApplication)
        {
            if (id != jobApplication.ApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobApplicationExists(jobApplication.ApplicationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Job_Id"] = new SelectList(_context.AddJobs, "Job_Id", "Job_Id", jobApplication.Job_Id);
            ViewData["Company_Id"] = new SelectList(_context.Companies, "Company_Id", "Company_Id", jobApplication.Company_Id);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", jobApplication.StudentId);
            return View(jobApplication);
        }

        // GET: JobApplications/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.JobApplications == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplications
                .Include(j => j.AddJobs)
                .Include(j => j.Company)
                .Include(j => j.Student)
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // POST: JobApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.JobApplications == null)
            {
                return Problem("Entity set 'MyDbContext.JobApplications'  is null.");
            }
            var jobApplication = await _context.JobApplications.FindAsync(id);
            if (jobApplication != null)
            {
                _context.JobApplications.Remove(jobApplication);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobApplicationExists(string id)
        {
          return (_context.JobApplications?.Any(e => e.ApplicationId == id)).GetValueOrDefault();
        }




        // GET: JobApplications/GetApplicationsByUserId
        //for student dashboard
        public async Task<IActionResult> GetApplicationsByUserId(string Id)
        {

            // Assuming you have some logic to retrieve the current student's ID
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(Id))
            {
                return BadRequest("User ID cannot be null or empty.");
            }

            var jobApplications = await _context.JobApplications
                .Where(j => j.User_id == currentUserId)
                .ToListAsync();

            Console.WriteLine(jobApplications);

            return View("GetApplicationsByUserId", jobApplications); // Assuming you have an Index view to display the job applications
        }

        //for company dashboard
        public async Task<IActionResult> GetApplicationsByCompanyId(string Id)
        {
            // Assuming you have some logic to retrieve the current user's ID
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Retrieve the company ID associated with the current user
            var company = await _context.Companies
                .FirstOrDefaultAsync(c => c.User_id == currentUserId);

            if (company == null)
            {
                return BadRequest("Company not found for the current user.");
            }

            Console.WriteLine(currentUserId);
            Console.WriteLine(company);
            Console.WriteLine(company.Company_Id);

            // Now that we have the company ID, let's query job applications by that company ID
            var jobApplications = await _context.JobApplications
                .Where(j => j.Company_Id == company.Company_Id)
                .ToListAsync();

            return View("GetApplicationsByCompanyId", jobApplications);
        }


    }
}
