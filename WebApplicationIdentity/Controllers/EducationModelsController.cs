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

namespace WebApplicationIdentity.Controllers
{
    [Authorize(Roles = "Student, Admin")]
    public class EducationModelsController : Controller
    {
        private readonly MyDbContext _context;


        public EducationModelsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: EducationModels
        public async Task<IActionResult> Index()
        {
              return _context.EducationModel != null ? 
                          View(await _context.EducationModel.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.EducationModel'  is null.");
        }


        // GET: EducationModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.EducationModel == null)
            {
                return NotFound();
            }

            var educationModel = await _context.EducationModel
                .FirstOrDefaultAsync(m => m.StudentEducation_Id == id);
            if (educationModel == null)
            {
                return NotFound();
            }

            return View(educationModel);
        }

        // GET: EducationModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentEducation_Id,Class10_Passing_Year,Class10_Percentage,Class12_Passing_Year,Class12_Percentage,Graduation_Completion_Year,Graduation_Percentage")] EducationModel educationModel)
        {
           /* if (ModelState.IsValid)
            {
                _context.Add(educationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educationModel);
*/
            _context.Add(educationModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: EducationModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.EducationModel == null)
            {
                return NotFound();
            }

            var educationModel = await _context.EducationModel.FindAsync(id);
            if (educationModel == null)
            {
                return NotFound();
            }
            return View(educationModel);
        }

        // POST: EducationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentEducation_Id,Class10_Passing_Year,Class10_Percentage,Class12_Passing_Year,Class12_Percentage,Graduation_Completion_Year,Graduation_Percentage")] EducationModel educationModel)
        {
            if (id != educationModel.StudentEducation_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationModelExists(educationModel.StudentEducation_Id))
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
            return View(educationModel);
        }

        // GET: EducationModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.EducationModel == null)
            {
                return NotFound();
            }

            var educationModel = await _context.EducationModel
                .FirstOrDefaultAsync(m => m.StudentEducation_Id == id);
            if (educationModel == null)
            {
                return NotFound();
            }

            return View(educationModel);
        }

        // POST: EducationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.EducationModel == null)
            {
                return Problem("Entity set 'MyDbContext.EducationModel'  is null.");
            }
            var educationModel = await _context.EducationModel.FindAsync(id);
            if (educationModel != null)
            {
                _context.EducationModel.Remove(educationModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationModelExists(string id)
        {
          return (_context.EducationModel?.Any(e => e.StudentEducation_Id == id)).GetValueOrDefault();
        }
    }
}
