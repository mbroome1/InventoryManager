namespace InventoryManager.Api.Entites
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Stock> Stock { get; set; } = new List<Stock>();
    }
}
