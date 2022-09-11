using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManager.Api.Migrations
{
    public partial class MakeCategoryIdFKNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Category_CategoryId",
                table: "Stock");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Stock",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Category_CategoryId",
                table: "Stock",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Category_CategoryId",
                table: "Stock");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Category_CategoryId",
                table: "Stock",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
