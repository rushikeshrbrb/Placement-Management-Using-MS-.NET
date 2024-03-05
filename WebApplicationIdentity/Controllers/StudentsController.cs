using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationIdentity.Data;
using WebApplicationIdentity.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplicationIdentity.Controllers
{
    [Authorize(Roles = "Student, Admin, Placement Officer, HOD, Company")]
    public class StudentsController : Controller
    {
        private readonly MyDbContext _context;

        
        public StudentsController(MyDbContext context) => _context = context;

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Student.Include(s => s.User);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Students/UploadResume/5
        public IActionResult UploadResume()
        {
           /* if (id == null)
            {
                return NotFound();
            }

           */ /*return View(id.Value);*/

           /* ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");*/
            return View();
        }


        // POST: Students/UploadResume/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadResume(int id, IFormFile resume)
        {
            if (resume == null || resume.Length == 0)
            {
                ModelState.AddModelError("resume", "Please select a file.");
                return View(id);
            }

            if (id <= 0)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resumes");
            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + resume.FileName;
            var filePath = Path.Combine(uploadsDirectory, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await resume.CopyToAsync(stream);
            }

            student.ResumeFilePath = uniqueFileName;
            _context.Update(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,email,UserId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", student.UserId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", student.UserId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentId,StudentName,email,UserId")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (!string.Equals(id?.Trim(), student.StudentId?.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Comparison failed");
                return NotFound();
            }
            else
            {
                Console.WriteLine("Comparison successful");

                _context.Update(student);
                await _context.SaveChangesAsync();
               // return RedirectToAction("");

            }

            /* if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(student);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!StudentExists(student.StudentId))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }
                 return RedirectToAction(nameof(Index));
             }*/
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", student.UserId);
            return View(student);

        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Student == null)
            {
                return Problem("Entity set 'MyDbContext.Student'  is null.");
            }
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
          return (_context.Student?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> GetAllCompanies()
        {
            var myDbContext = _context.Companies.Include(c => c.User);
            return View(await myDbContext.ToListAsync());
        }


        public async Task<IActionResult> JobInfo(string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            // Assuming there's a relationship between User and Company, and you have a Users table
            var user = await _context.Users
                .Include(u => u.Company)  // Include the Company navigation property if it exists
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null || user.Company == null)
            {
                return NotFound();
            }

            // Fetch all jobs for a specific company based on Company_Id
            var jobsForCompany = await _context.AddJobs
                .Include(a => a.Company)
                .FirstOrDefaultAsync(j => j.Company_Id == user.Company.Company_Id);  // Assuming CompanyId is the property holding the company id


            /*if (jobsForCompany == null || jobsForCompany.Count == 0)
            {
                return NotFound();
            }*/

            return View(new List<AddJobs> { jobsForCompany });
        }

        public async Task<IActionResult> ByStudent(string id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var student = await _context.Student
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.UserId == id);

            if (student == null)
            {
                return NotFound();
            }


            return View(new List<Student> { student });
        }

        [HttpGet]
        public IActionResult LoadPartialView()
        {
          
            return View();
        }


        // GET: Students/ApplyJob
        public IActionResult ApplyJob()
        {
            return View();
        }

        // POST: Students/ApplyJob
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyJob(JobApplication model)
        {
            
                // Map the view model to the JobApplication entity
                var jobApplication = new JobApplication
                {
                    Email = model.Email,
                    MobileNo = model.MobileNo,
                    Experience = model.Experience,
                    GraduationYear = model.GraduationYear,
                    skills = model.skills,
                    // Assuming StudentId, Company_Id, and Job_Id are set appropriately based on the context
                    StudentId = model.StudentId,
                    Company_Id = model.Company_Id,
                    Job_Id = model.Job_Id,
                    Status = ApplicationStatus.PENDING // Set default status as pending
                };

                // Add job application to the context and save changes
                _context.JobApplications.Add(jobApplication);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); // Redirect to the desired action
            
           
            // If model state is not valid, return the view with validation errors
            return View(model);
        }
    }
}
