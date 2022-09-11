using InventoryManager.Api.DbContexts;
using InventoryManager.Api.Entites;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Api.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly InventoryManagerDbContext _context;

        public CategoryRepository(InventoryManagerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Category.OrderBy(c => c.Name).ToListAsync();
        }
        public async Task<Category?> GetCategory(int categoryId)
        {
            return await _context.Category.Where(c => c.Id == categoryId).Include(s => s.Stock).FirstOrDefaultAsync();
        }
    }
}
