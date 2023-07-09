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
    public class Funding_PackageController : Controller
    {
        private readonly CrmDbContext _context;

        public Funding_PackageController(CrmDbContext context)
        {
            _context = context;
        }

        // GET: Funding_Package
        public async Task<IActionResult> Index()
        {
              return _context.Funding_Packages != null ? 
                          View(await _context.Funding_Packages.ToListAsync()) :
                          Problem("Entity set 'CrmDbContext.Funding_Packages'  is null.");
        }

        // GET: Funding_Package/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Funding_Packages == null)
            {
                return NotFound();
            }

            var funding_Package = await _context.Funding_Packages
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (funding_Package == null)
            {
                return NotFound();
            }

            return View(funding_Package);
        }

        // GET: Funding_Package/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funding_Package/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackageId,PackageName,PackageValue,PackageRewared")] Funding_Package funding_Package)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funding_Package);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funding_Package);
        }

        // GET: Funding_Package/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Funding_Packages == null)
            {
                return NotFound();
            }

            var funding_Package = await _context.Funding_Packages.FindAsync(id);
            if (funding_Package == null)
            {
                return NotFound();
            }
            return View(funding_Package);
        }

        // POST: Funding_Package/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackageId,PackageName,PackageValue,PackageRewared")] Funding_Package funding_Package)
        {
            if (id != funding_Package.PackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funding_Package);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Funding_PackageExists(funding_Package.PackageId))
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
            return View(funding_Package);
        }

        // GET: Funding_Package/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funding_Packages == null)
            {
                return NotFound();
            }

            var funding_Package = await _context.Funding_Packages
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (funding_Package == null)
            {
                return NotFound();
            }

            return View(funding_Package);
        }

        // POST: Funding_Package/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funding_Packages == null)
            {
                return Problem("Entity set 'CrmDbContext.Funding_Packages'  is null.");
            }
            var funding_Package = await _context.Funding_Packages.FindAsync(id);
            if (funding_Package != null)
            {
                _context.Funding_Packages.Remove(funding_Package);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Funding_PackageExists(int id)
        {
          return (_context.Funding_Packages?.Any(e => e.PackageId == id)).GetValueOrDefault();
        }
    }
}
