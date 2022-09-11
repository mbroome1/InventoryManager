using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManager.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    StockOnHand = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Category 1" },
                    { 2, "Category 2" },
                    { 3, "Category 3" },
                    { 4, "Category 4" }
                });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "StockOnHand" },
                values: new object[] { 1, 1, "Description of Stock 1 is here", "Stock Name of item 1", 10.99m, 50 });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "StockOnHand" },
                values: new object[] { 2, 3, "Description of Stock 2 is here", "Stock Name of item 2", 4.99m, 24 });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "StockOnHand" },
                values: new object[] { 3, 2, "Description of Stock 3 is here", "Stock Name of item 3", 24.99m, 6 });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_CategoryId",
                table: "Stock",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
