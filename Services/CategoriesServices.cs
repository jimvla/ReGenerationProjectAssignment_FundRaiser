using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReGenerationProjectAssignment_FundRaiser.DbContexts;
using ReGenerationProjectAssignment_FundRaiser.Models;

namespace ReGenerationProjectAssignment_FundRaiser.Services
{
    public class CategoriesServices : ICategoiesServices
    {
        private readonly CrmDbContext _context;

        public CategoriesServices(CrmDbContext context)
        {
            _context = context;
        }
        public bool CheckNull()
        {
            return _context.Category == null;
        }
        public async Task<List<Category>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            
            return await _context.Category.FirstOrDefaultAsync(m => m.CategoryId == id);
        }

        public async Task CreateCategory(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category != null)
            {
                _context.Category.Remove(category);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCategory(Category category)
        {
            _context.Update(category);
            return await _context.SaveChangesAsync();
        }
    }
}
