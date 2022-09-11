using InventoryManager.Api.Entites;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Api.Models
{
    public class StockDto
    {
        //public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [Precision(10, 2)]
        public decimal Price { get; set; } = decimal.Zero;
        public int StockOnHand { get; set; } = 0;

        public Category? Category { get; set; }

    }
}
