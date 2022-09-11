using InventoryManager.Api.Entites;

namespace InventoryManager.Api.Services
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category?> GetCategory(int id);

    }
}
