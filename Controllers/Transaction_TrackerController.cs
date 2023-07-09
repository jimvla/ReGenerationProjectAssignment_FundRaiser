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
    public class Transaction_TrackerController : Controller
    {
        private readonly CrmDbContext _context;

        public Transaction_TrackerController(CrmDbContext context)
        {
            _context = context;
        }

        // GET: Transaction_Tracker
        public async Task<IActionResult> Index()
        {
              return _context.Transaction_Tracker != null ? 
                          View(await _context.Transaction_Tracker.ToListAsync()) :
                          Problem("Entity set 'CrmDbContext.Transaction_Tracker'  is null.");
        }

        // GET: Transaction_Tracker/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Transaction_Tracker == null)
            {
                return NotFound();
            }

            var transaction_Tracker = await _context.Transaction_Tracker
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction_Tracker == null)
            {
                return NotFound();
            }

            return View(transaction_Tracker);
        }

        // GET: Transaction_Tracker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transaction_Tracker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId")] Transaction_Tracker transaction_Tracker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction_Tracker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transaction_Tracker);
        }

        // GET: Transaction_Tracker/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Transaction_Tracker == null)
            {
                return NotFound();
            }

            var transaction_Tracker = await _context.Transaction_Tracker.FindAsync(id);
            if (transaction_Tracker == null)
            {
                return NotFound();
            }
            return View(transaction_Tracker);
        }

        // POST: Transaction_Tracker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TransactionId")] Transaction_Tracker transaction_Tracker)
        {
            if (id != transaction_Tracker.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction_Tracker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Transaction_TrackerExists(transaction_Tracker.TransactionId))
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
            return View(transaction_Tracker);
        }

        // GET: Transaction_Tracker/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Transaction_Tracker == null)
            {
                return NotFound();
            }

            var transaction_Tracker = await _context.Transaction_Tracker
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction_Tracker == null)
            {
                return NotFound();
            }

            return View(transaction_Tracker);
        }

        // POST: Transaction_Tracker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Transaction_Tracker == null)
            {
                return Problem("Entity set 'CrmDbContext.Transaction_Tracker'  is null.");
            }
            var transaction_Tracker = await _context.Transaction_Tracker.FindAsync(id);
            if (transaction_Tracker != null)
            {
                _context.Transaction_Tracker.Remove(transaction_Tracker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Transaction_TrackerExists(string id)
        {
          return (_context.Transaction_Tracker?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
