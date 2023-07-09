using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReGenerationProjectAssignment_FundRaiser.DbContexts;
using ReGenerationProjectAssignment_FundRaiser.Models;

namespace ReGenerationProjectAssignment_FundRaiser.Controllers
{
    public class Project_TrackerController : Controller
    {
        private readonly CrmDbContext _context;

        public Project_TrackerController(CrmDbContext context)
        {
            _context = context;
        }

        // GET: Project_Tracker
        public async Task<IActionResult> Index()
        {
              return _context.Project_Tracker != null ? 
                          View(await _context.Project_Tracker.ToListAsync()) :
                          Problem("Entity set 'CrmDbContext.Project_Tracker'  is null.");
        }

        // GET: Project_Tracker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Project_Tracker == null)
            {
                return NotFound();
            }

            var project_Tracker = await _context.Project_Tracker
                .FirstOrDefaultAsync(m => m.TrackerId == id);
            if (project_Tracker == null)
            {
                return NotFound();
            }

            return View(project_Tracker);
        }

        // GET: Project_Tracker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project_Tracker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrackerId,Amount")] Project_Tracker project_Tracker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project_Tracker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project_Tracker);
        }

        // GET: Project_Tracker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Project_Tracker == null)
            {
                return NotFound();
            }

            var project_Tracker = await _context.Project_Tracker.FindAsync(id);
            if (project_Tracker == null)
            {
                return NotFound();
            }
            return View(project_Tracker);
        }

        // POST: Project_Tracker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrackerId,Amount")] Project_Tracker project_Tracker)
        {
            if (id != project_Tracker.TrackerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project_Tracker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Project_TrackerExists(project_Tracker.TrackerId))
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
            return View(project_Tracker);
        }

        // GET: Project_Tracker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Project_Tracker == null)
            {
                return NotFound();
            }

            var project_Tracker = await _context.Project_Tracker
                .FirstOrDefaultAsync(m => m.TrackerId == id);
            if (project_Tracker == null)
            {
                return NotFound();
            }

            return View(project_Tracker);
        }

        // POST: Project_Tracker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Project_Tracker == null)
            {
                return Problem("Entity set 'CrmDbContext.Project_Tracker'  is null.");
            }
            var project_Tracker = await _context.Project_Tracker.FindAsync(id);
            if (project_Tracker != null)
            {
                _context.Project_Tracker.Remove(project_Tracker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Project_TrackerExists(int id)
        {
          return (_context.Project_Tracker?.Any(e => e.TrackerId == id)).GetValueOrDefault();
        }
    }
}
