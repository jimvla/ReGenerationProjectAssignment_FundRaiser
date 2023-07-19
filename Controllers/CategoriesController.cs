using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReGenerationProjectAssignment_FundRaiser.DbContexts;
using ReGenerationProjectAssignment_FundRaiser.Models;
using ReGenerationProjectAssignment_FundRaiser.Services;

namespace ReGenerationProjectAssignment_FundRaiser.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoiesServices _service;
        public CategoriesController(ICategoiesServices Service)
        {
            _service = Service;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
              return await _service.GetCategories() != null ? 
                          View(_service.GetCategories()) :
                          Problem("Entity set 'CrmDbContext.Category'  is null.");
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service.CheckNull())
            {
                return NotFound();
            }

            var category = await _service.GetCategory((int)id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryDescription")] Category category)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service.CheckNull())
            {
                return NotFound();
            }

            var category = await _service.GetCategory((int)id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,CategoryDescription")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateCategory(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _service.CheckNull())
            {
                return NotFound();
            }

            var category = await _service.GetCategory((int)id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service.CheckNull())
            {
                return Problem("Entity set 'CrmDbContext.Category'  is null.");
            }
            await _service.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return _service.GetCategory(id)!= null? true : false;
        }
    }
}
