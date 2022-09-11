using InventoryManager.Api.Entites;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Api.DbContexts
{
    public class InventoryManagerDbContext : DbContext
    {
        public DbSet<Stock> Stock { get; set; } = null!;
        public DbSet<Category> Category { get; set; } = null!;

        public InventoryManagerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().HasData(
                    new Stock()
                    {
                        Id = 1,
                        Name = "Stock Name of item 1",
                        Description = "Description of Stock 1 is here",
                        Price = 10.99m,
                        StockOnHand = 50,
                        CategoryId = 1
                    },
                    new Stock()
                    {
                        Id = 2,
                        Name = "Stock Name of item 2",
                        Description = "Description of Stock 2 is here",
                        Price = 4.99m,
                        StockOnHand = 24,
                        CategoryId = 3
                    },
                    new Stock()
                    {
                        Id = 3,
                        Name = "Stock Name of item 3",
                        Description = "Description of Stock 3 is here",
                        Price = 24.99m,
                        StockOnHand = 6,
                        CategoryId = 2
                    }
                );

            modelBuilder.Entity<Category>().HasData(
                    new Category()
                    {
                        Id = 1,
                        Name = "Category 1"
                    },
                    new Category()
                    {
                        Id = 2,
                        Name = "Category 2"
                    },
                    new Category()
                    {
                        Id = 3,
                        Name = "Category 3"
                    },
                    new Category()
                    {
                        Id = 4,
                        Name = "Category 4"
                    }
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}
