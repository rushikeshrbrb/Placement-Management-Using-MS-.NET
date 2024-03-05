using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationIdentity.Data;
using WebApplicationIdentity.Models;

namespace WebApplicationIdentity.Controllers
{
    [Authorize(Roles = "Company, Admin, Placement Officer, HOD")]
    public class CompaniesController : Controller
    {
        private readonly MyDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CompaniesController(MyDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Companies.Include(c => c.User);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Company_Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            ViewData["User_id"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Company_Id,nameOfRepresentative,Company_Name,User_id,Website,City,Contact_No")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["User_id"] = new SelectList(_context.Users, "Id", "Id", company.User_id);
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            ViewData["User_id"] = new SelectList(_context.Users, "Id", "Id", company.User_id);
            return View(company);
        }

        // POST: Companies/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Company_Id,nameOfRepresentative,Company_Name,User_id,Website,City,Contact_No")] Company company)
        {
            try
            {
                if (id == null || _context.Companies == null)
                {
                    return NotFound();
                }

                Console.WriteLine($"Before comparison: id: '{id}', company.Company_Id: '{company.Company_Id}'");

                if (!string.Equals(id?.Trim(), company.Company_Id?.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Comparison failed");
                    return NotFound();
                }
                else
                {
                    Console.WriteLine("Comparison successful");

                    _context.Update(company);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction("ByCompany");

                }



                /*if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(company);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CompanyExists(company.Company_Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Index");
                }*/
            }
            catch (Exception ex)
            {
                // Log the exception to investigate further
                Console.WriteLine($"Exception in Edit action: {ex}");
            }

            ViewData["User_id"] = new SelectList(_context.Users, "Id", "Id", company.User_id);
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Company_Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Companies == null)
            {
                return Problem("Entity set 'MyDbContext.Companies'  is null.");
            }
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(string id)
        {
            return (_context.Companies?.Any(e => e.Company_Id == id)).GetValueOrDefault();
        }


        // GET: Companies/ByCompany?id=
        public async Task<IActionResult> ByCompany(string id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var company = await _context.Companies
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.User_id == id);

            if (company == null)
            {
                return NotFound();
            }


            return View(new List<Company> { company });
        }



        [HttpGet]
        public IActionResult LoadPartialView()
        {

            return View();
        }

           [HttpGet]
           public async Task<IActionResult> ViewJobApplications(string jobId)
           {
               // Retrieve the job applications for the specified job
               var jobApplications = await _context.JobApplications
                   .Where(ja => ja.Job_Id == jobId)
                   .ToListAsync();

            Console.WriteLine(jobApplications);

               return View(jobApplications);
           }


        //for company dashboard
        public async Task<IActionResult> GetJobsByCompanyId(string id)
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

            // Retrieve jobs associated with the found company ID
            var jobs = await _context.AddJobs
                .Where(j => j.Company_Id == company.Company_Id)
                .ToListAsync();

            return View("GetJobsByCompanyId", jobs);
        }




    }
}