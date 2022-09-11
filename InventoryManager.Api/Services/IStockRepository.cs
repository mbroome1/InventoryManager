using InventoryManager.Api.Entites;

namespace InventoryManager.Api.Services
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllStock();
        Task<Stock?> GetStockById(int id);
        //Task<Stock?> GetStockByName(string name);
        Task<bool> StockExists(int id);
        void CreateStock(Stock stock);
        void DeleteStock(Stock stock);
        Task<bool> SaveChanges();
    }
}
