using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationIdentity.Data;
using WebApplicationIdentity.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplicationIdentity.Controllers
{
    [Authorize(Roles ="Company,Admin")]
    public class AddJobsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MyDbContext _context;

        public AddJobsController(MyDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: AddJobs
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.AddJobs.Include(a => a.Company);
            return View(await myDbContext.ToListAsync());
        }

        // GET: AddJobs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AddJobs == null)
            {
                return NotFound();
            }

            var addJobs = await _context.AddJobs
                .Include(a => a.Company)
                .FirstOrDefaultAsync(m => m.Job_Id == id);
            if (addJobs == null)
            {
                return NotFound();
            }


            return View(addJobs);
        }
        

        // GET: AddJobs/Create
        public IActionResult  Create()
        {
            // Get the currently logged-in user_userManager.GetUserAsync(User);
            var currentUser = _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Login", "Account");
            }

            // Assuming that User_id in the Company model corresponds to the ID of the logged-in user
            var companyId = currentUser.Id;

            ViewData["Company_Id"] = new SelectList(_context.Companies, "Company_Id", "Company_Id", companyId);
            return View();
        }

        // POST: AddJobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Job_Id,Company_Id,Designation,Specialization,Experience,Description,_10_cri,_12_cri,Grad_cri,Status,CTC")] AddJobs addJobs)
        {
            // Set the Company_Id to the ID of the currently logged-in company
            //var currentUser = await _userManager.GetUserAsync(User);
            addJobs.Company_Id = addJobs.Company_Id;
            _context.Add(addJobs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            /*if (ModelState.IsValid)
            {
                _context.Add(addJobs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }*/

            ViewData["Company_Id"] = new SelectList(_context.Companies, "Company_Id", "Company_Id", addJobs.Company_Id);
            return View(addJobs);
        }

        // GET: AddJobs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AddJobs == null)
            {
                return NotFound();
            }

            var addJobs = await _context.AddJobs.FindAsync(id);
            if (addJobs == null)
            {
                return NotFound();
            }

            ViewData["Company_Id"] = new SelectList(_context.Companies, "Company_Id", "Company_Id", addJobs.Company_Id);

            // Instead of redirecting to Index, return the View for editing
            return View(addJobs);
        }

        // POST: AddJobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Job_Id,Company_Id,Designation,Specialization,Experience,Description,_10_cri,_12_cri,Grad_cri,Status,CTC")] AddJobs addJobs)
        {
            if (id != addJobs.Job_Id)
            {
                return NotFound();
            }

            if (!string.Equals(id?.Trim(), addJobs.Job_Id?.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Comparison failed");
                return NotFound();
            }
            else
            {
                Console.WriteLine("Comparison successful");
                _context.Update(addJobs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

                // Instead of updating immediately, check if the model state is valid
                /* if (ModelState.IsValid)
                 {
                     try
                     {
                         _context.Update(addJobs);
                         await _context.SaveChangesAsync();
                     }
                     catch (DbUpdateConcurrencyException)
                     {
                         if (!AddJobsExists(addJobs.Job_Id))
                         {
                             return NotFound();
                         }
                         else
                         {
                             throw;
                         }
                     }

                     // Return to the Index view after a successful update
                     return RedirectToAction(nameof(Index));
                 }*/
            }

            // If ModelState is not valid, return the Edit view with the current model
            ViewData["Company_Id"] = new SelectList(_context.Companies, "Company_Id", "Company_Id", addJobs.Company_Id);
            return View(addJobs);
        }

        // GET: AddJobs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AddJobs == null)
            {
                return NotFound();
            }

            var addJobs = await _context.AddJobs
                .Include(a => a.Company)
                .FirstOrDefaultAsync(m => m.Job_Id == id);
            if (addJobs == null)
            {
                return NotFound();
            }

            return View(addJobs);
        }

        // POST: AddJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AddJobs == null)
            {
                return Problem("Entity set 'MyDbContext.AddJobs'  is null.");
            }
            var addJobs = await _context.AddJobs.FindAsync(id);
            if (addJobs != null)
            {
                _context.AddJobs.Remove(addJobs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddJobsExists(string id)
        {
          return (_context.AddJobs?.Any(e => e.Job_Id == id)).GetValueOrDefault();
        }

        /*public  IActionResult ByCompany()
        {
            return View();

        }*/

        public async Task<IActionResult> ByCompany(string userId)
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



        // GET: AddJobs/EditJobByCompany/5
        public async Task<IActionResult> EditJobByCompany(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.AddJobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // POST: AddJobs/EditJobByCompany/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditJobByCompany(string id, [Bind("Job_Id,Designation,Specialization,Experience,Description,_10_cri,_12_cri,Grad_cri,Status,CTC")] AddJobs job)
        {
            try
            {
                _context.Update(job);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(job.Job_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("GetjobsByCompanyId", "Companies");
            return RedirectToAction(nameof(Index));

            return View(job);
        }

        // GET: AddJobs/DeleteJobByCompany/5
        public async Task<IActionResult> DeleteJobByCompany(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.AddJobs
                .FirstOrDefaultAsync(m => m.Job_Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: AddJobs/DeleteConfirmedByCompany/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedByCompany(string id)
        {
            var job = await _context.AddJobs.FindAsync(id);
            _context.AddJobs.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetjobsByCompanyId", "Companies");
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(string id)
        {
            return _context.AddJobs.Any(e => e.Job_Id == id);
        }
    }



}
