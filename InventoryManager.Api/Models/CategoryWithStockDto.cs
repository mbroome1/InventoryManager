using InventoryManager.Api.Entites;

namespace InventoryManager.Api.Models
{
    public class CategoryWithStockDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Stock> Stock { get; set; } = new List<Stock>();
    }
}
