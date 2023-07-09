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
    public class Status_UpdateController : Controller
    {
        private readonly CrmDbContext _context;

        public Status_UpdateController(CrmDbContext context)
        {
            _context = context;
        }

        // GET: Status_Update
        public async Task<IActionResult> Index()
        {
              return _context.Status_Updates != null ? 
                          View(await _context.Status_Updates.ToListAsync()) :
                          Problem("Entity set 'CrmDbContext.Status_Updates'  is null.");
        }

        // GET: Status_Update/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Status_Updates == null)
            {
                return NotFound();
            }

            var status_Update = await _context.Status_Updates
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (status_Update == null)
            {
                return NotFound();
            }

            return View(status_Update);
        }

        // GET: Status_Update/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Status_Update/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusId,Message,DateTime")] Status_Update status_Update)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status_Update);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(status_Update);
        }

        // GET: Status_Update/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Status_Updates == null)
            {
                return NotFound();
            }

            var status_Update = await _context.Status_Updates.FindAsync(id);
            if (status_Update == null)
            {
                return NotFound();
            }
            return View(status_Update);
        }

        // POST: Status_Update/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusId,Message,DateTime")] Status_Update status_Update)
        {
            if (id != status_Update.StatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(status_Update);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Status_UpdateExists(status_Update.StatusId))
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
            return View(status_Update);
        }

        // GET: Status_Update/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Status_Updates == null)
            {
                return NotFound();
            }

            var status_Update = await _context.Status_Updates
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (status_Update == null)
            {
                return NotFound();
            }

            return View(status_Update);
        }

        // POST: Status_Update/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Status_Updates == null)
            {
                return Problem("Entity set 'CrmDbContext.Status_Updates'  is null.");
            }
            var status_Update = await _context.Status_Updates.FindAsync(id);
            if (status_Update != null)
            {
                _context.Status_Updates.Remove(status_Update);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Status_UpdateExists(int id)
        {
          return (_context.Status_Updates?.Any(e => e.StatusId == id)).GetValueOrDefault();
        }
    }
}
