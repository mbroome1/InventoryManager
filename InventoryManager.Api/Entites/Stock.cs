using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.Api.Entites
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [Precision(10,2)]
        public decimal Price { get; set; }
        public int StockOnHand { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
    }
}
