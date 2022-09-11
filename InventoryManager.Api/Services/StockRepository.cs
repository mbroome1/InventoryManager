using InventoryManager.Api.DbContexts;
using InventoryManager.Api.Entites;
using InventoryManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Api.Services
{
    public class StockRepository : IStockRepository
    {
        private readonly InventoryManagerDbContext _context;

        public StockRepository(InventoryManagerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<IEnumerable<Stock>> GetAllStock()
        {
            return await _context.Stock.OrderBy(s => s.Name).Include(c => c.Category).ToListAsync();
        }

        public async Task<Stock?> GetStockById(int id)
        {
            return await _context.Stock.Where(s => s.Id == id).Include(c => c.Category).FirstOrDefaultAsync();
        }

        public void CreateStock(Stock stock)
        {
            _context.Stock.Add(stock);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >=0);
        }

        public async Task<bool> StockExists(int id)
        {
            return await _context.Stock.AnyAsync(s => s.Id == id);
        }

        public void DeleteStock(Stock stock)
        {
            _context.Stock.Remove(stock);
        }
    }
}
