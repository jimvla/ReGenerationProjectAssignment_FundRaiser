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
    public class ProjectsController : Controller
    {
        private readonly CrmDbContext _context;

        public ProjectsController(CrmDbContext context)
        {
            _context = context;
        }

        public IActionResult TechProjects()
        {
            var techprojects = _context.Projects
                .Include("Category")
                .Where(p => p.Category.CategoryId == 1)
                .ToList();

            return View(techprojects);
        }

        public IActionResult ArtProjects()
        {
            var artprojects = _context.Projects
                .Include("Category")
                .Where(p => p.Category.CategoryId == 2)
                .ToList();

            return View(artprojects);
        }

        public IActionResult HomeProjects()
        {
            var homeprojects = _context.Projects
                .Include("Category")
                .Where(p => p.Category.CategoryId == 3)
                .ToList();

            return View(homeprojects);
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
              return _context.Projects != null ? 
                          View(await _context.Projects.ToListAsync()) :
                          Problem("Entity set 'CrmDbContext.Projects'  is null.");
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            var categories = await _context.Category.FirstOrDefaultAsync(c => c.CategoryId == project.CategoryId);
            ViewData["Categories"] = categories;
            if (project == null)
            {
                return NotFound();
            }
             
            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            var categories = _context.Category
                .Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName
                    })
                .ToList();

            ViewData["Categories"] = categories;

            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,Title,Description,ImageURL,VideoURL,FundingGoal,CategoryId")] Project project)
        {
            if (ModelState.IsValid)
            {
                List<Funding_Package> fund = new();
                foreach (Funding_Package f in _context.Funding_Packages)
                {
                    fund.Add(f);
                }
                project.Funding_Packages = fund;
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(project);
            //return View("Index"); //Redirects to index page when done
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            var categories = _context.Category
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.CategoryName
                })
                .ToList();

            ViewData["Categories"] = categories;

            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,Title,Description,ImageURL,VideoURL,FundingGoal,CategoryId")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
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
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projects == null)
            {
                return Problem("Entity set 'CrmDbContext.Projects'  is null.");
            }
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
          return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> AddValue(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/AddValue
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddValue(int id, [Bind("TotalAmount")] Project newProject)
        {
            var project = await _context.Projects
                        .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (id != newProject.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    project.TotalAmount += newProject.TotalAmount;
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
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

            return View(project);
        }
    }
}
