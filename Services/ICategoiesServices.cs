using ReGenerationProjectAssignment_FundRaiser.Models;

namespace ReGenerationProjectAssignment_FundRaiser.Services
{
    public interface ICategoiesServices
    {
        public Task<List<Category>> GetCategories();
        public Task<Category> GetCategory(int id);
        public Task CreateCategory(Category category);
        public Task<int> UpdateCategory(Category category);
        public Task<int> DeleteCategory(int id);
        public bool CheckNull();
    }
}
