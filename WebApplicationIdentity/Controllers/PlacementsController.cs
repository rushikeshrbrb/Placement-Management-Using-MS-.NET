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
    [Authorize(Roles = "Admin, Placement Officer, HOD")]
    public class PlacementsController : Controller
    {
        private readonly MyDbContext _context;

        public PlacementsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Placements
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.placements.Include(p => p.Student);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Placements/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.placements == null)
            {
                return NotFound();
            }

            var placement = await _context.placements
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.Placement_Id == id);
            if (placement == null)
            {
                return NotFound();
            }

            return View(placement);
        }

        // GET: Placements/Create
        public IActionResult Create()
        {
            ViewData["Student_Id"] = new SelectList(_context.Student, "StudentId", "StudentId");
            return View();
        }

        // POST: Placements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Placement_Id,Student_Id,Placement_Status,Placement_Company,Placement_Salary")] Placement placement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Student_Id"] = new SelectList(_context.Student, "StudentId", "StudentId", placement.Student_Id);
            return View(placement);
        }

        // GET: Placements/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.placements == null)
            {
                return NotFound();
            }

            var placement = await _context.placements.FindAsync(id);
            if (placement == null)
            {
                return NotFound();
            }
            ViewData["Student_Id"] = new SelectList(_context.Student, "StudentId", "StudentId", placement.Student_Id);
            return View(placement);
        }

        // POST: Placements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Placement_Id,Student_Id,Placement_Status,Placement_Company,Placement_Salary")] Placement placement)
        {
            if (id != placement.Placement_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacementExists(placement.Placement_Id))
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
            ViewData["Student_Id"] = new SelectList(_context.Student, "StudentId", "StudentId", placement.Student_Id);
            return View(placement);
        }

        // GET: Placements/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.placements == null)
            {
                return NotFound();
            }

            var placement = await _context.placements
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.Placement_Id == id);
            if (placement == null)
            {
                return NotFound();
            }

            return View(placement);
        }

        // POST: Placements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.placements == null)
            {
                return Problem("Entity set 'MyDbContext.Placement'  is null.");
            }
            var placement = await _context.placements.FindAsync(id);
            if (placement != null)
            {
                _context.placements.Remove(placement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacementExists(string id)
        {
          return (_context.placements?.Any(e => e.Placement_Id == id)).GetValueOrDefault();
        }
    }
}
