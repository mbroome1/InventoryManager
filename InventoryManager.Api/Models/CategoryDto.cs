using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Api.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
